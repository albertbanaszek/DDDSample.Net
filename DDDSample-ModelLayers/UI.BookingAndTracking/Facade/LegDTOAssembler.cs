using System;
using System.Linq;
using System.Collections.Generic;
using DDDSample.Domain.Location;
using DDDSample.DomainModel.Operations.Cargo;
using DDDSample.DomainModel.Potential.Location;

namespace DDDSample.UI.BookingAndTracking.Facade
{
   public class LegDTOAssembler
   {
      private readonly ILocationRepository _locationRepository;

      public LegDTOAssembler(ILocationRepository locationRepository)
      {
         _locationRepository = locationRepository;
      }

      public Leg FromDTO(LegDTO legDto)
      {
         return new Leg(null, _locationRepository.Find(new UnLocode(legDto.From)),
            legDto.LoadTime,
            _locationRepository.Find(new UnLocode(legDto.To)),
            legDto.UnloadTime);
      }

      public LegDTO ToDTO(Leg leg)
      {
         return new LegDTO("XXX",
                           leg.LoadLocation.UnLocode.CodeString,
                           leg.UnloadLocation.UnLocode.CodeString,
                           leg.LoadDate,
                           leg.UnloadDate);
      }
   }
}