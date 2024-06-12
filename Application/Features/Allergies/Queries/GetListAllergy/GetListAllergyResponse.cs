using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Features.Allergies.Queries.GetListAllergy
{
    public class GetListAllergyResponse
    {
        public List<Allergy> Allergies { get; set; }
    }
}
