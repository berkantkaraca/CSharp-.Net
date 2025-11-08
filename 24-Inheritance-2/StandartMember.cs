namespace _24_Inheritance_2
{
    public class StandartMember : BaseMember
    {
        public bool Kit { get; set; }
        public StandartMember(string firstName, string lastName, DateTime joinedAt) : base(firstName, lastName, joinedAt)
        {
        }

        public override decimal MembershipFee(int month)
        {
            var price = base.MembershipFee(month);
            return Kit ? price + 3000 : price;
        }

        public override string ToString()
        {
            return base.ToString() + ", Ücret: " + MembershipFee(12);
        }
    }
}
