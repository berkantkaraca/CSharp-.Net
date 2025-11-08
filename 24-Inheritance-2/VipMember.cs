namespace _24_Inheritance_2
{
    public class VipMember : BaseMember
    {
        public string Coach { get; set; }
        public VipMember(string firstName, string lastName, DateTime joinedAt, string coach) : base(firstName, lastName, joinedAt)
        {
            _price = 7500;
            Coach = coach;
        }

        public override decimal MembershipFee(int month)
        {
            return base.MembershipFee(month) + 10000;
        }

        public override string ToString()
        {
            return base.ToString() + ", Koç: " + Coach + ", Ücret: " + MembershipFee(12);
        }
    }
}
