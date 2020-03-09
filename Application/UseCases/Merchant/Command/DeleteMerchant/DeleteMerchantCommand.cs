using MediatR;
using ValidationWithMediatr_task.Domain.Models;

namespace ValidationWithMediatr_task.Application.UseCases.Merchant.Command.DeleteMerchant
{
    public class DeleteMerchantCommand : IRequest<DeleteMerchantCommandDto>
    {
        public int id { get; set; }

        public DeleteMerchantCommand(int Id)
        {
            id = Id;
        }
    }
}