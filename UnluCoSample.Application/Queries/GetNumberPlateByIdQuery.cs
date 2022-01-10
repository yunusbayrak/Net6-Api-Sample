using MediatR;
using UnluCoSample.Application.Responses;

namespace UnluCoSample.Application.Queries
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
