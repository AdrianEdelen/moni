using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace moni.Helpers
{
    public class ImageHelper
    {
        public static async Task<byte[]> AssignAvatarAsync(string avatar)
        {
            var defaultAvatarPath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\img", avatar);
            return await File.ReadAllBytesAsync(defaultAvatarPath);
        }
    }
}
