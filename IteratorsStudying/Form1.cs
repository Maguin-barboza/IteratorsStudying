using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IteratorsStudying
{
    public partial class Form1 : Form
    {
        Stack<string> stack = new Stack<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnExecutar_Click(object sender, EventArgs e)
        {
            labelStatus.Text = "Rodando";

            await Task.Run(() =>
            {
                foreach (string msg in stack)
                {
                   this.Invoke((MethodInvoker)delegate
                   {
                       LstMensagens.Items.Add(msg);
                   });

                    Thread.Sleep(1000);
                }
            });

            labelStatus.Text = "Parado";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            stack.Push(textBox1.Text);
            textBox1.Text = "";
            textBox1.Focus();
        }

        private void btnPop_Click(object sender, EventArgs e)
        {
            LstMensagens.Items.Add(stack.Pop());
        }
    }


    public class Stack<T> : IEnumerable
    {
        private List<T> Itens = new List<T>();
        private int Index = -1;

        public void Push(T item)
        {
            Index++;
            Itens.Insert(Index, item);
        }

        public T Pop()
        {
            T item;
            item = Itens[Index];
            Index--;

            return item;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = Index; i >= 0 ; i--)
            {
                yield return Itens[i];
            }
        }
    }
}
