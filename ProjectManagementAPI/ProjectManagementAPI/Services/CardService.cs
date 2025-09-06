using Microsoft.EntityFrameworkCore;
using ProjectManagementAPI.Infra;
using ProjectManagementAPI.Models.Requests.Card;
using ProjectManagementAPI.Models.Requests.Column;
using ProjectManagementAPI.Models.Response.Card;
using ProjectManagementAPI.Models.Response.Column;
using ProjectManagementAPI.Models.Schema;
using ProjectManagementAPI.Services.Interfaces;

namespace ProjectManagementAPI.Services
{
    public class CardService(DbSetConfig dbContext) : ICardService
    {
        private readonly DbSetConfig _dbContext = dbContext;
        public async Task<(object?, bool, string)> GetCardById(Guid Id)
        {
            try
            {
                Guid guidResult;
                if (!Guid.TryParse(Id.ToString(), out guidResult))
                    return (null, false, "invalid guid");


                var card = await _dbContext.Cards.Where(x => x.CardID == Id).FirstOrDefaultAsync();

                if (card is null)
                    return (null, false, "not found with this id");

                return (card, true, "success to get a card");
            }
            catch (Exception ex)
            {
                return (null, false, $"failed to get a card with this id. Error: {ex.Message}");
            }
        }

        public async Task<(object?, bool, string)> GetCardByColumnId(Guid columnId)
        {
            try
            {
                var columns = await _dbContext.Cards
                    .Where(x => x.ColumnID == columnId)
                    .ToListAsync();

                if (columns.Count <= 0)
                    return (null, false, "not found any card");

                return (columns, true, $"success to get all the card for this board");
            }
            catch (Exception ex)
            {
                return (null, false, $"failed to get the card with this board id. Error: {ex.Message}");
            }
        }

        public async Task<(object?, bool, string)> CreateNewCard(CreateCardRequest request)
        {
            try
            {
                var newCard = new Card()
                {
                    CardID = Guid.NewGuid(),
                    ColumnID = request.ColumnID,
                    CreateDate = DateTime.UtcNow,
                    CardTitle = request.CardTitle,
                    CardContent = request.CardContent,
                };

                var response = await _dbContext.Cards.AddAsync(newCard);
                await _dbContext.SaveChangesAsync();

                var returnObject = new CreateCardResponse()
                {
                    CardId = newCard.CardID,
                    CardTitle = request.CardTitle,
                };

                return (returnObject, true, "success to create a new card.");
            }
            catch (Exception ex)
            {
                return (null, false, $"failed to create a new card. Error: {ex.Message}");
            }
        }

        public async Task<(object?, bool, string)> UpdateCard(UpdateCardRequest updateRequest)
        {
            try
            {
                var card = await _dbContext.Cards.FindAsync(updateRequest.CardId);

                if (card == null)
                    return (null, false, "not found this card");

                card.UpdateDate = DateTime.UtcNow;

                if (updateRequest.ColumnID != null)
                    card.ColumnID = updateRequest.ColumnID;

                if (updateRequest.CardTitle != null)
                    card.CardTitle = updateRequest.CardTitle;

                if (updateRequest.CardContent != null)
                    card.CardContent = updateRequest.CardContent;

                _dbContext.Cards.Update(card);
                await _dbContext.SaveChangesAsync();

                var responseObject = new UpdateCardResponse()
                {
                    CardId = card.CardID,
                    ColumnID = card.ColumnID,
                    CardTitle = card.CardTitle,
                    CardContent = card.CardContent,
                };

                return (responseObject, true, "success to udpate this card");
            }
            catch (Exception ex)
            {
                return (null, false, $"failed to update this card. Error: {ex.Message}");
            }
        }

        public async Task<(object?, bool, string)> DeleteCard(Guid id)
        {
            try
            {
                var card = await _dbContext.Cards.FindAsync(id);

                if (card == null)
                    return (null, false, "not found this card");

                _dbContext.Cards.Remove(card);
                await _dbContext.SaveChangesAsync();

                return (card, true, "success to delete this card");
            }
            catch (Exception ex)
            {
                return (null, false, $"failed to delete this card. Error: {ex.Message}");
            }
        }
    }
}
