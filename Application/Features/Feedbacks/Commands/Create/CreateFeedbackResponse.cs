using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Feedbacks.Commands.Create
{
    public class CreateFeedbackResponse
    {
        public int Id { get; set; }
        public string UserMail { get; set; }
        public string UserFeedback { get; set; }
    }
}
