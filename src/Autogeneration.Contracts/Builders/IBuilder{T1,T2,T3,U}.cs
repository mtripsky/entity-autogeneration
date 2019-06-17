using System;

namespace Autogeneration.Contracts.Builders
{
    public interface IBuilder<T1,T2,T3,U>
    {
        U Build(T1 item1, T2 item2, T3 item3);
    }
}
