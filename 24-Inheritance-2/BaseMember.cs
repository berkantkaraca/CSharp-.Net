using _24_Inheritance_2.Validations;

namespace _24_Inheritance_2
{
    public class BaseMember
    {
        private string _firstName;
        private string _lastName;
        private DateTime _joinedAt;
        protected decimal _price = 5000;

        //protected olduğundan child class'lar dışında instance oluşturulamaz. abstract kullanılması lazım bu senaryolarda.
        protected BaseMember(string firstName, string lastName, DateTime joinedAt)
        {
            JoinedAt = joinedAt;
            LastName = lastName;
            FirstName = firstName;
        }

        public DateTime JoinedAt
        {
            get { return _joinedAt; }
            set
            {
                _joinedAt = DateValidation.CheckDate(value);
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set {
                _lastName = CheckValidation.CheckValue(value);
            }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = CheckValidation.CheckValue(value);

            }
        }

        public virtual decimal MembershipFee(int month)
        {
            return _price * month;
        }

        public string FullName => _firstName + " " + _lastName.ToUpper();

        public override string ToString()
        {
            return $"Üye: {FullName}, Kayıt Tarihi: {JoinedAt}";

        }
    }

    public class Deneme : BaseMember
    {
        public Deneme(string firstName, string lastName, DateTime joinedAt) : base(firstName, lastName, joinedAt)
        {
        }
    }
}
