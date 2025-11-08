namespace _29_Interface_Lab
{
    //eğer interface oluşturup bırakırsan marker interface olur. Bir özellik sağlamaz ama mesela hepsi IPayment içinde toplanabilir
    public interface IPayment
    {
        void MakePayment();
        void CancelPayment();
    }
}
