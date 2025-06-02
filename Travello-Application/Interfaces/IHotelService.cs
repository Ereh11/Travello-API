using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travello_Application.Common.Result;
using Travello_Application.Dtos.Hotel;

namespace Travello_Application.Interfaces
{
    public interface IHotelService
    {
        Task<GeneralResult> AddHotel(AddHotelDto addHotelDto);
    }
}
