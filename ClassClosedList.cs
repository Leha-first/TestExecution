using System;
using System.Collections;
using System.Collections.Generic;

namespace ImplementationIClosedList
{
    /// <summary>
    /// Класс, реализующий интерфейс IClosedList
    /// </summary>
    /// <typeparam name="T"> T </typeparam>
    public class ClassClosedList<T> : IClosedList<T>
    {
        private int currentIndex;
        /// <summary>
        /// Указатель на текущий элемент
        /// </summary>
        private int CurrentIndex {
            get => currentIndex;
            set { if (value < 0) { currentIndex = CurrentList.Count + value; _headReached?.Invoke(null, CurrentList[0]); }
                else if (value >= CurrentList.Count) { currentIndex = value - CurrentList.Count; _headReached?.Invoke(null, CurrentList[0]); }
                else currentIndex = value; }
        }
        /// <summary>
        /// Список с элементами
        /// </summary>
        private List<T> CurrentList { get; } = new List<T>();

        /// <summary>
        /// Получение или установка элемента по индексу
        /// </summary>
        /// <param name="index"> Индекс </param>
        /// <returns> T </returns>
        T IList<T>.this[int index] {
            get { if (index < 0 || index >= CurrentList.Count) throw new IndexOutOfRangeException();
                else return CurrentList[index]; }
            set { if (index < 0 || index >= CurrentList.Count) throw new IndexOutOfRangeException();
                else CurrentList.Insert(index, value); } }

        /// <summary>
        /// Свойство Head для возврата элемента коллекции с нулевым индексом
        /// </summary>
        T IClosedList<T>.Head => CurrentList.Count > 0 ? CurrentList[0] : default;
        /// <summary>
        /// Получение текщего элемента коллекции
        /// </summary>
        T IClosedList<T>.Current => CurrentList[CurrentIndex];
        /// <summary>
        /// Получение предыдущего элемента коллекции
        /// </summary>
        T IClosedList<T>.Previous
        {
            get
            {
                if (CurrentIndex - 1 < 0) return CurrentList[CurrentList.Count - 1];
                else return CurrentList[CurrentIndex - 1];
            }
        }
        /// <summary>
        /// Получение следующего элемента коллекции
        /// </summary>
        T IClosedList<T>.Next
        {
            get
            {
                if (CurrentIndex + 1 >= CurrentList.Count) return CurrentList[0];
                else return CurrentList[CurrentIndex + 1];
            }
        }
        /// <summary>
        /// Количество элементов в коллекции
        /// </summary>
        int ICollection<T>.Count => CurrentList.Count;
        /// <summary>
        /// Логическое значение - только для чтения
        /// </summary>
        bool ICollection<T>.IsReadOnly => default(bool);

        private EventHandler<T> _headReached;
        /// <summary>
        /// Событие прохождения через элемент с нулевым индексом
        /// </summary>
        event EventHandler<T> IClosedList<T>.HeadReached
        {
            add { _headReached += value; }
            remove { _headReached -= value; }
        }

        /// <summary>
        /// Метод добавления нового элемента в коллекцию
        /// </summary>
        /// <param name="item"> Экземпляр элемента </param>
        void ICollection<T>.Add(T item) =>
            CurrentList.Add(item);

        /// <summary>
        /// Удаление всех элементов из коллекции
        /// </summary>
        void ICollection<T>.Clear() => CurrentList.Clear();

        /// <summary>
        /// Метод определяет, содержит ли коллекция определенный элемент
        /// </summary>
        /// <param name="item"> Экземпляр элемента </param>
        /// <returns> Логическое значение </returns>
        bool ICollection<T>.Contains(T item) => CurrentList.Contains(item);

        /// <summary>
        /// Метод для копирования элементов коллекции в массив начиная с указанного индекса
        /// </summary>
        /// <param name="array"> Массив </param>
        /// <param name="arrayIndex"> Индекс массива </param>
        void ICollection<T>.CopyTo(T[] array, int arrayIndex) =>
            CurrentList.CopyTo(array, arrayIndex);
        /// <summary>
        /// Возврат Enumerator<T>
        /// </summary>
        /// <returns> Enumerator<T> </returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator() =>
            CurrentList.GetEnumerator();
        /// <summary>
        /// Возврат Enumerator
        /// </summary>
        /// <returns> Enumerator </returns>
        IEnumerator IEnumerable.GetEnumerator() => CurrentList.GetEnumerator();
        /// <summary>
        /// Возврат индекса элемента в коллекции
        /// </summary>
        /// <param name="item"> Экземпляр элемента </param>
        /// <returns> Индекс нахождения элемента </returns>
        int IList<T>.IndexOf(T item) => CurrentList.IndexOf(item);
        /// <summary>
        /// Метод для вставки элемента в указанный индекс
        /// </summary>
        /// <param name="index"> Индекс </param>
        /// <param name="item"> Экземпляр элемента </param>
        void IList<T>.Insert(int index, T item) => CurrentList.Insert(index, item);
        /// <summary>
        /// Перемещение по коллекции в обратном направлении
        /// </summary>
        /// <param name="step"> Шаг </param>
        void IClosedList<T>.MoveBack(int step) =>
            CurrentIndex -= step;
            
        /// <summary>
        /// Перемещение по коллекции в прямом направлении
        /// </summary>
        /// <param name="step"> Шаг </param>
        void IClosedList<T>.MoveNext(int step) => CurrentIndex += step;
        /// <summary>
        /// Удаление элемента из коллекции
        /// </summary>
        /// <param name="item"> Экземпляр элемента </param>
        /// <returns> Логическое значение - успешно ли произведено удаление </returns>
        bool ICollection<T>.Remove(T item) => CurrentList.Remove(item);
        /// <summary>
        /// Удаление элемента из коллекции по указанному индексу
        /// </summary>
        /// <param name="index"> Индекс </param>
        void IList<T>.RemoveAt(int index) => CurrentList.RemoveAt(index);
    }
}
