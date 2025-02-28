using dotnety.Application.Responses;
using MediatR;

namespace dotnety.Application.Queries
{
    public class GetNumberPlateByIdQuery : IRequest<GetNumberPlateResponse>
    {
        public int Id { get; set; }
        public GetNumberPlateByIdQuery(int id)
        {
            Id = id;
        }
    }
}
