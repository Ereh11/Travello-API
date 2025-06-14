﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travello_Domain.Interfaces;

public interface IImageRepository
{
    Task<string> UploadImageAsync(IFormFile file);
}
