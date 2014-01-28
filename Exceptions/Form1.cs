using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Exceptions
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Exceptions();

            CustomExceptions();
        }

        private void CustomExceptions()
        {
            try
            {
                TestCustomExceptions();
            }
            catch (MyException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TestCustomExceptions()
        {
            throw new MyException("Test custom exception");
        }

        class MyException : ApplicationException
        {
            public MyException(string exceptionText) : base(exceptionText) { }
            public MyException(string exceptionText, Exception innerException) : base(exceptionText, innerException) { }
        }

        private void Exceptions()
        {
            int numerator = 10;
            int denominator = 0;
            int result;

            try
            {
                if (denominator == 0)
                {
                    DivideByZeroException exception = new DivideByZeroException("Invalid denominator (0)");
                    exception.Data.Add("Numerator", numerator);
                    throw exception;
                }
                else
                result = numerator / denominator;
            }
            catch (System.IO.IOException ex)
            {
                MessageBox.Show("IOException: " + ex.Message);
            }
           catch (DivideByZeroException ex)
            {
                if (ex.Data != null && ex.Data["Numerator"] != null)
                    MessageBox.Show(ex.Message + ", numerator: " + ex.Data["Numerator"].ToString());
                else
                MessageBox.Show("DivideByZeroException: " + ex.Message);
            }
        
            catch (StackOverflowException ex)
            {
                MessageBox.Show("StackOverflowException: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }
            finally
            {
                MessageBox.Show("Finally block");
            }
        }
    }
}