using System;

class Sort
{
    Random rnd;

    public Sort()
    {
        rnd = new Random();
    }

    public void Selection_Sort(ref int[] arr)
    {
        int N = arr.Length;
        for (int j = 0; j < N - 1; j++)
        {
            int min = j;
            for (int i = j + 1; i < N; i++)
            {
                if (arr[min] > arr[i])
                {
                    min = i;
                }
            }
            Swap(ref arr, j, min);
        }
    }

    public void Insertion_Sort(ref int[] arr)
    {
        int N = arr.Length;
        for(int j = 1; j < N; j++)
        {
            int sel = arr[j];
            int i = j;
            while(--i >= 0 && sel < arr[i])
                arr[i + 1] = arr[i];
            arr[i + 1] = sel;
        }
    }

    public void Merge_Sort(ref int[] arr)
    {
        int N = arr.Length;
        Merge_Sort_(ref arr, 0, N - 1);
    }
    private void Merge_Sort_(ref int[] arr, int s, int e)
    {
        if (s >= e)
            return;

        int mid = (s + e + 1) / 2;
        Merge_Sort_(ref arr, s, mid - 1);
        Merge_Sort_(ref arr, mid, e);
        
        //Merge
        int[] t = new int[e - s + 1];
        int p1 = 0, p2 = 0;
        while(s + p1 <= mid - 1 || mid + p2 <= e)
        {
            if(s + p1 <= mid - 1 && mid + p2 <= e)
            {
                if(arr[s + p1] < arr[mid + p2])
                {
                    t[p1 + p2] = arr[s + p1];
                    p1++;
                }
                else
                {
                    t[p1 + p2] = arr[mid + p2];
                    p2++;
                }
            }else if(s + p1 <= mid - 1)
            {
                t[p1 + p2] = arr[s + p1];
                p1++;
            }
            else
            {
                t[p1 + p2] = arr[mid + p2];
                p2++;
            }
        }

        for(int j = 0; j < p1 + p2; j++)
            arr[s + j] = t[j];
    }

    public void Heap_Sort(ref int[] arr)
    {
        int N = arr.Length;

        //BUILD HEAP
        for(int j = N / 2 - 1; j >= 0; j--)
        {
            MAX_Heapify(ref arr, N, j);
        }

        //EXTRACT MAX
        for(int j = 0; j < N - 1; j++)
        {
            Swap(ref arr, 0, N - 1 - j);
            MAX_Heapify(ref arr, N - j - 1, 0);
        }
    }
    private void MAX_Heapify(ref int[] arr, int N, int i)
    {
        int left = (i + 1) * 2 - 1;
        int right = (i + 1) * 2;
        if ((left < N && arr[i] < arr[left]) || (right < N && arr[i] < arr[right]))
        {
            if((left < N && arr[i] < arr[left]) && (right < N && arr[i] < arr[right]))
            {
                if(arr[left] > arr[right])
                {
                    Swap(ref arr, i, left);
                    MAX_Heapify(ref arr, N, left);
                }
                else
                {
                    Swap(ref arr, i, right);
                    MAX_Heapify(ref arr, N, right);
                }
            }else if(left < N && arr[i] < arr[left])
            {
                Swap(ref arr, i, left);
                MAX_Heapify(ref arr, N, left);
            }
            else
            {
                Swap(ref arr, i, right);
                MAX_Heapify(ref arr, N, right);
            }
        }
    }

    public void Quick_Sort(ref int[] arr)
    {
        int N = arr.Length;
        Quick_Sort_(ref arr, 0, N - 1);
    }
    private void Quick_Sort_(ref int[] arr, int s, int e)
    {
        if (s >= e)
            return;
        
        int pivot = e;
        Swap(ref arr, pivot, rnd.Next(s, e + 1)); //Randomized Sort
        int i = s, j = e - 1;
        int min = arr[pivot], max = arr[pivot]; //모든 숫자가 동일한 경우

        for (int k = s; k < e; k++)
        {
            min = Math.Min(min, arr[i]);
            max = Math.Max(max, arr[i]);

            if(arr[i] < arr[pivot])
                i++;
            else
            {
                Swap(ref arr, i, j);
                j--;
            }
        }
        Swap(ref arr, pivot, j + 1);

        if (min == max) return;
        Quick_Sort_(ref arr, s, j);
        Quick_Sort_(ref arr, j + 1, e);
    }

    private void Swap(ref int[] arr, int i, int j)
    {
        int t = arr[i];
        arr[i] = arr[j];
        arr[j] = t;
    }
}