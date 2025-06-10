using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travello_Domain.Interfaces;

public interface IHotelImageRepository
{
    Task AddImageAsync(HotelImage image);
}
