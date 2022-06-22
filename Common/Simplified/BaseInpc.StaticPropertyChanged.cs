using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Simplified
{
    // Добавлена реализация для статических свойств
    public abstract partial class BaseInpc : INotifyPropertyChanged
    {
        /// <summary>Событие уведомляющее об изменении статических свойств.</summary>
        public static event EventHandler<PropertyChangedEventArgs> StaticPropertyChanged;

        /// <summary>Защищённый метод для создания события <see cref="PropertyChanged"/>.</summary>
        /// <param name="propertyName">Имя изменившегося свойства. 
        /// Если значение не задано, то используется имя метода в котором был вызов.</param>
        protected static void RaiseStaticPropertyChanged([CallerMemberName] string propertyName = null)
        {
            StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>Защищённый метод для присвоения значения полю и
        /// создания события <see cref="StaticPropertyChanged"/>.</summary>
        /// <typeparam name="T">Тип поля и присваиваемого значения.</typeparam>
        /// <param name="propertyField">Ссылка на поле.</param>
        /// <param name="newValue">Присваиваемое значение.</param>
        /// <param name="propertyName">Имя изменившегося свойства. 
        /// Если значение не задано, то используется имя метода в котором был вызов.</param>
        /// <param name="equality">Делегат для сравнения значения поля с новым значением.</param>
        /// <returns>Возвращает <see langword="true"/>, если значение изменилось и
        /// было поднято событие <see cref="StaticPropertyChanged"/>.</returns>
        /// <remarks>Метод предназначен для использования в сеттере свойства.<br/>
        /// Сравнение нового значения со значением поля производится следующим образом:<br/>
        /// - Если оба равны <see langword="null"/>, то считаются равными;<br/>
        /// - Если один равен <see langword="null"/>, а другой нет, то считаются неравными;<br/>
        /// - Если оба не равны <see langword="null"/>, то сравниваются ссылки на объекты;<br/>
        /// - Если ссылки на разные объекты, то сравниваются делегатом <paramref name="equality"/>;<br/>
        /// - Если делегат <paramref name="equality"/> равен <see langword="null"/>,
        /// то сравниваются методом <see cref="IEquatable{T}.Equals(T)"/>, если он есть у <typeparamref name="T"/>, или <see cref="object.Equals(object, object)"/>.<br/>
        /// Если присваиваемое значение не эквивалентно значению поля, то оно присваивается полю.<br/>
        /// После присвоения создаётся событие <see cref="PropertyChanged"/> вызовом
        /// метода <see cref="RaiseStaticPropertyChanged(string)"/>
        /// с передачей ему параметра <paramref name="propertyName"/>.</remarks>
        protected static bool StaticSet<T>(ref T propertyField, T newValue, Equality<T> equality = null, [CallerMemberName] string propertyName = null)
        {
            bool isFieldNull = propertyField == null;
            bool isValueNull = newValue == null;

            bool isEquals = isFieldNull && isValueNull;
            if (!(isFieldNull || isValueNull))
            {
                isEquals = ReferenceEquals(propertyField, newValue) ||
                            (
                                equality != null
                                ? equality(propertyField, newValue)
                                : propertyField is IEquatable<T> equatable
                                  ? equatable.Equals(newValue)
                                  : propertyField.Equals(newValue)
                            );
            }

            if (!isEquals)
            {
                T oldValue = propertyField;
                propertyField = newValue;
                RaiseStaticPropertyChanged(propertyName);
            }

            return !isEquals;
        }
    }
}
