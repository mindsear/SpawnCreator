using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpawnCreator.Definitions
{
    enum RelationType
    {
        RELATION_SELF = 0,
        RELATION_IN_PARTY,
        RELATION_IN_RAID_OR_PARTY,
        RELATION_OWNED_BY,
        RELATION_PASSENGER_OF,
        RELATION_CREATED_BY,
        RELATION_MAX
    }
}
