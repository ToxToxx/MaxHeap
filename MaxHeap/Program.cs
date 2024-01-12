namespace MaxHeap
{
    class MaxHeap
    {
        private int[] heap;
        private int size;
        private int capacity;

        public MaxHeap(int capacity)
        {
            this.capacity = capacity;
            size = 0;
            heap = new int[capacity + 1];
        }

        private int Parent(int i) => i / 2;
        private int LeftChild(int i) => 2 * i;
        private int RightChild(int i) => 2 * i + 1;

        private void Swap(int i, int j)
        {
            int temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }

        public void Insert(int value)
        {
            if (size == capacity)
            {
                Console.WriteLine("Переполнение кучи");
                return;
            }

            size++;
            int i = size;
            heap[i] = value;

            while (i > 1 && heap[Parent(i)] < heap[i])
            {
                Swap(i, Parent(i));
                i = Parent(i);
            }
        }

        public int ExtractMax()
        {
            if (size <= 0)
            {
                Console.WriteLine("Куча недополнена");
                return -1; 
            }

            if (size == 1)
            {
                size--;
                return heap[1];
            }

            int max = heap[1];
            heap[1] = heap[size];
            size--;
            MaxHeapify(1);

            return max;
        }

        private void MaxHeapify(int i)
        {
            int left = LeftChild(i);
            int right = RightChild(i);
            int largest = i;

            if (left <= size && heap[left] > heap[i])
            {
                largest = left;
            }

            if (right <= size && heap[right] > heap[largest])
            {
                largest = right;
            }

            if (largest != i)
            {
                Swap(i, largest);
                MaxHeapify(largest);
            }
        }

        public void PrintHeap()
        {
            for (int i = 1; i <= size; i++)
            {
                Console.Write(heap[i] + " ");
            }
            Console.WriteLine();
        }
        public void DrawMaxHeap()
        {
            DrawMaxHeapRec(1, 0);
        }

        private void DrawMaxHeapRec(int index, int level)
        {
            if (index <= size)
            {
                DrawMaxHeapRec(RightChild(index), level + 1);

                for (int i = 0; i < level; i++)
                {
                    Console.Write("    ");
                }

                Console.WriteLine(heap[index]);

                DrawMaxHeapRec(LeftChild(index), level + 1);
            }
        }
    }

    class Program
    {
        static void Main()
        {
            MaxHeap maxHeap = new MaxHeap(10);

            maxHeap.Insert(4);
            maxHeap.Insert(10);
            maxHeap.Insert(8);
            maxHeap.Insert(5);
            maxHeap.Insert(1);

            Console.WriteLine("Схема двоичной кучи");
            maxHeap.DrawMaxHeap();

            Console.WriteLine("Двоичная куча:");
            maxHeap.PrintHeap();

            int max = maxHeap.ExtractMax();
            Console.WriteLine("Удаление максимального элемента: " + max);

            Console.WriteLine("Двоичная куча после удаления:");
            maxHeap.PrintHeap();

            maxHeap.Insert(6);
            Console.WriteLine("Схема двоичной кучи");
            maxHeap.DrawMaxHeap();
        }
    }
}