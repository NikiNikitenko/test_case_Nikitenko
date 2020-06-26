using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_case_Nikitenko.Core.Data
{
    class Profile
    {
        public string inn;
        //1. Ідентифікаційний код юридичної особи
        public string supervisoryAuthority;
        //2. Контролюючий орган
        public string scopeOfControl;
        //3. Сфера контролю
        public string checkN;
        //4. Перевірка №
        public string verificationStatus;
        //5. Статус перевірки
        public string degreeOfRisk;
        //6. Ступінь ризику
        public string typeChecking;
        //7. Тип перевірки
        public string sanctions;
        //8. Санкції(грн.)
        public string dates;
        //9. Дати проведення
        public string link;
        //10. Посилання на картку з результатами
        
    }
}
