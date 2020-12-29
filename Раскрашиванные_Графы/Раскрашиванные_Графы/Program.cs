using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
	static public int Draw_Graph(int VertexCount, int[,] Graph)
	{
		int p, k, cur, i, j, pos;
		int[] GrFifo;
		int[] GrColors;
		int[] GrSet;
		int Start;

		GrColors = new int[VertexCount];    // Массив для сохранения цветов, в который разрисованы вершины графа на соотвественном шаге

		GrFifo = new int[VertexCount];      // Структуры данных " Очередь"
		GrSet = new int[VertexCount];       // Массив для хранения вершин, которые уже разрисованы

		for (i = 0; i < VertexCount; i++)
		{
			GrColors[i] = 0;
			GrFifo[i] = 0;
			GrSet[i] = 0;
		}

		for (int t = 0; t < VertexCount; t++)
		{
			Start = t;                  // Выбор начальной вершины
			if (GrColors[Start] == 0)
				GrColors[Start] = 1;    // Раскрашиваем  первую вершину в цвет 1
			p = 0;                      //начало очереди
			k = 1;                      //конец очереди
			GrFifo[p] = Start;          // Помещяем начальную вершину в очередь
			while (p != k)
			{
				cur = GrFifo[p];        // Помещение очередной вершины в очередь
				p++;                    // Двигает начало очереди на 1
				for (i = 0; i < VertexCount; i++)
					if ((Graph[cur, i] == 1) & (GrColors[i] == 0))
					{
						GrFifo[k] = i;  // Помещает вершину в очередь
						k++;            // Двигает конец очереди
						pos = 0;        // Формируем множество цветов, в который разрисованы смежные вершины
						for (j = 0; j < VertexCount; j++)
							if ((Graph[GrFifo[k - 1], j] == 1) & (GrColors[j] != 0))
							{
								GrSet[pos] = GrColors[j];
								pos++;
							}
						GrColors[i] = Find(pos, GrSet);
					}
			}
		}
		return GrColors.Distinct().Count();//Количество различающихся элементов
	}
	static public int Find(int pos, int[] Set) //Раскрашивает вершину в минимальный цвет
	{
		int Min_color, i, p;
		Min_color = 0;
		do
		{
			Min_color++;
			p = 0;
			for (i = 0; i < pos; i++)
				if (Set[i] == Min_color)
				{
					p = 1;
					break;
				}
		}
		while (p != 0);
		return Min_color;       // Возвращает минимальный цвет
	}
	/*
	public class Ras
    {
		void print(int i,StreamWriter fs,int[] a)
		{
		
			int j;
			for (j = 0; j < i; j++)
			{
				fs.Write(a[j] + " ");
			}
			fs.WriteLine();
		
		}
		
		///n - осталось набрать слагаемых на сумму n
		//k - слагаемые не больше k
		//i - номер очередного слагаемого
		 
		//В массиве a, начиная с i-го элемента, перебрать все возможные
		//варианты разложения числа n на слагаемые, не превосходящие k.
		
		void dec(int n, int k, int i,int[] a,StreamWriter fs)
		{
			if (n < 0) return;
			if (n == 0)
			{
				// Просьба разложить 0 означает, что раскладывать уже нечего и
				// и уже нет остаточного значения, котрое нужно разложить.
				// Значит в массиве {a[0], a[1], ... a[i-1]} находится некоторое готовое разложение
				// исходного числа n = m.
				print(i,fs,a);
		
			}
			else
			{
				if (n - k >= 0)
				{
					a[i] = k; // фиксируем i-ое слагаемое
					dec(n - k, k, i + 1,a,fs);
				}
		
				if (k - 1 > 0)
				{
					dec(n, k - 1, i,a,fs);
				}
			}
		}
		
		
		public Ras(int p)
		{
			int[] a = new int[100];
			FileInfo output = new FileInfo("out_ras.txt");
			StreamWriter fs = output.CreateText();
			int num, i, count;

			Console.WriteLine("Введите число, которое нужно разложить ");
			
			for (i = 0; i <= p; i++)
			{
				a[i] = 0;
			}
			dec(p, p, 0,a,fs);
			fs.Close();

		}
	}
	*/
	struct Edge
	{
		public int first;
		public int second;

		public void DisplayInfo()
		{
			Console.WriteLine($"First: {first}  Second: {second}");
		}
	}
	
	static bool NextCombobj(int[] soc, int n, int k)
	{

		for (int i = k - 1; i >= 0; --i)//начинаем идти с конца в начало
			if (soc[i] < n - k + i)
			{
				soc[i]++;//берем следующий элемент

				for (int j = i + 1; j < k; j++)//следующий элемент меняем на предыдущий + 1
					soc[j] = soc[j - 1] + 1;

				return true;

			}
		return false;
	}
	static public void Reset(ref int[,] arr, int n, int m) //Обнуление массива
	{
		for (int i = 0; i < n; i++)
			for (int j = 0; j < m; j++)
				arr[i, j] = 0;
	}
	static public void PrintArray(int[] arr, int n, StreamWriter fs)
	{

		fs.WriteLine();
		for (int i = 0; i < n; i++)
		{
				fs.Write(arr[i] + " ");
		}
		fs.WriteLine();

	}
	static public void PrintArray(int[,] arr, int n, int m, StreamWriter fs)
	{
		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < m; j++)
				fs.Write(arr[i, j] + " ");

			fs.WriteLine();
		}
		fs.WriteLine("---------------------------------");

	}

	//Факториал числа
	static public int Factorial(int value)
    {
		int Factorial = 1;
		for(int i = 2; i <= value; i++)
        {
			Factorial *= i;
        }
		return Factorial;
    }

	//Задача:для заданных значений p,q и k построить все возможные k раскрашенные графы
	static void Main()
	{
		int p, k, q;

		Console.Write("Введите количество вершин = ");
		p = Convert.ToInt32(Console.ReadLine());

		Console.Write("Введите количество ребер = ");
		q = Convert.ToInt32(Console.ReadLine());

		Console.Write("Введите количество цветов = ");
		k = Convert.ToInt32(Console.ReadLine());

		//Разбили наше число количества вершин на подмножества
		//Ras test = new Ras(p);

		int kol_P_Q_K_ = 1/Factorial(k) ;//Количество k раскрашенных графов
		
		Console.Write($"Всего таких графов  = {kol_P_Q_K_}\n");


		
		int[] soc = new int[2];

		for (int i = 0; i < 2; i++)
			soc[i] = i;

		int m = 0;//счетчик ребер

		Edge[] edge = new Edge[50];//Массив ребер

		edge[m].first = soc[0];
		edge[m].second = soc[1];
		m++;
		if (p > 2)
		{
			//Построения всех возможных ребер в заданном графе
			while (NextCombobj(soc, p, 2))
			{
				edge[m].first = soc[0];
				edge[m].second = soc[1];
				m++;
			}
		}
		else Console.WriteLine("Условие не выполняется");


		Console.WriteLine($"{m} - максимальное количество ребер ");



		for (int i = 0; i < m; i++)
		{
			edge[i].DisplayInfo(); //Вывод всех ребер
		}

		if (q <= m)
		{
			Console.WriteLine($"Строим сочитания из ребер");

			FileInfo output = new FileInfo("out.txt");
			StreamWriter fs = output.CreateText();

			int kol_P_Q_K = 0;//Счетчик числа p,q графов

			int[,] Matrix = new int[p, p];
			Reset(ref Matrix, p, p);

			int[] socq = new int[q];

			for (int i = 0; i < q; i++)
			{

				socq[i] = i;
				Console.Write(socq[i] + " ");
				//Заполняем таблицу смежности
				Matrix[edge[socq[i]].first, edge[socq[i]].second] = 1;
				Matrix[edge[socq[i]].second, edge[socq[i]].first] = 1;
			}
			Console.WriteLine();

			//Проверка на число цветов в графе
			if (Draw_Graph(p, Matrix) <= k)
			{

				PrintArray(Matrix, p, p, fs); //выводим в файл
				kol_P_Q_K++;//Количество таких графов
			}

			Reset(ref Matrix, p, p); //обнуляем

			{

				//Строим сочитания из ребер
				while (NextCombobj(socq, m, q))
				{
					for (int i = 0; i < q; i++)
					{
						Console.Write(socq[i] + " ");
						//Заполняем таблицу смежности
						Matrix[edge[socq[i]].first, edge[socq[i]].second] = 1;
						Matrix[edge[socq[i]].second, edge[socq[i]].first] = 1;

					}
					Console.WriteLine();

					if (Draw_Graph(p, Matrix) <= k)
					{	
						PrintArray(Matrix, p, p, fs); //выводим в файл
						kol_P_Q_K++;//Количество таких графов
					}

					Reset(ref Matrix, p, p); //обнуляем
					
				}

			}

			fs.WriteLine("Количество графов - " + kol_P_Q_K);
			fs.Close();
		}
		else Console.WriteLine("Число заданных ребер больше допустимого числа");
		Console.WriteLine("Программа завершена");
		
		Console.ReadKey();
	}
}

