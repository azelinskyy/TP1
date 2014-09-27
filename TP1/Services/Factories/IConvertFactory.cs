namespace Services.Factories
{
    using Model.DomainModels;

    public interface IConvertFactory<T1, T2>
        where T1 : DomainModel
        where T2 : class
    {
        T2 FromModel(T1 model);

        T1 ToModel(T2 obj);
    }
}
