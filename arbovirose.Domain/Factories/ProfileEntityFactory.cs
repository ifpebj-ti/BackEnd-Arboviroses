using arbovirose.Domain.Dtos.Profile;
using arbovirose.Domain.Entities;
using arbovirose.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arbovirose.Domain.Factories
{
    public class ProfileEntityFactory
    {
        public static ProfileEntity CreateProfileEntity(CreateProfileDTO data) 
        {
            return new ProfileEntity(
                new Office(data.Office)
            );
        } 
    }
}
