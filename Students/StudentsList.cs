using TwoLinkedListsLibrary;

namespace Practice
{
    public class StudentsList : TwoLinkedList<Students>
    {
        public override void Sort()
        {
            if (head == null)
                throw new Exception("List is empty!");
            bool swapped;
            ListNode<Students> start = head;
            ListNode<Students> end = null;

            do
            {
                swapped = false;
                ListNode<Students> current = start;

                while (current.Next != end)
                {
                    if (CompareStudents(current.Data, current.Next.Data) > 0)
                    {
                        Swap(current, current.Next);
                        swapped = true;
                    }
                    current = current.Next;
                }

                end = current;
                if (!swapped)
                    break;

                swapped = false;
                current = current.Previous;

                while (current != start)
                {
                    if (CompareStudents(current.Data, current.Previous.Data) < 0)
                    {
                        Swap(current, current.Previous);
                        swapped = true;
                    }
                    current = current.Previous;
                }
                start = current.Next;
            } while (swapped);
        }
        
        private int CompareStudents(Students a, Students b)
        {
            return a.Height.CompareTo(b.Height); // здійснюємо порівняння за компонентою 
        }

        // метод пошуку студентів з ідеальною вагою
        public override List<Students> Find()
        {
            List<Students> StudentsWithIdealWeight = new List<Students>();

            ListNode<Students> current = head;
            while (current != null)
            {
                double idealWeight = current.Data.Height - 110;
                if (Math.Abs(current.Data.Weight - idealWeight) < 0.01)
                    StudentsWithIdealWeight.Add(current.Data);

                current = current.Next;
            }
            return StudentsWithIdealWeight;
        }
    }
}
