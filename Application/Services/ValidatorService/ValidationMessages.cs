using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.ValidatorService
{
    public static class ValidationMessages
    {
        public const string Required = "{PropertyName} alanı zorunlu";
        public const string InvalidFormat = "Lütfen geçerli bir {PropertyName} giriniz";
        public const string Length = "{PropertyName} {MinLength} ve {MaxLength} arasında karakterden oluşmalıdır";
        public const string OnlyLetters = "{PropertyName} yalnızca harflerden oluşmalıdır";
    }
}
