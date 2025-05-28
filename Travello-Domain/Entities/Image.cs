using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travello_Domain;

public class Image
{
    public Guid ImageId { get; set; }
    public string ImageURL { get; set; } = string.Empty;

}
