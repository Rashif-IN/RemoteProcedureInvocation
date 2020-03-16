
using MediatR;
using user_handler.Model;

namespace user_handler.UseCase.User.Command.Put
{
    public class Command : RequestData<user_model>, IRequest<Dto>
    {
        public int Id { get; set; }
        public Command(int id)
        {
            Id = id;
        }
    }
}
