using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MyCalc
{

    public partial class Form2 : Form
    {
        int lines = 0;
        double memory = 0;
        int pressedMR = 0;
        MyCalcNumber memNum = new MyCalcNumber();
        MyCalcNumber lastFirst = new MyCalcNumber();
        MyCalcNumber lastSecond = new MyCalcNumber();
        MyInternalKey lastOperator = new MyInternalKey();
        string Fname;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            initGlobal();
            memNum.setNumber("0");
            lastFirst.setNumber("0");
            lastSecond.setNumber("0");
            lastOperator = MyInternalKey.IK_OPERATOR_START;

            openFileDialog1.ShowDialog();
            Fname = openFileDialog1.FileName;
            if (Fname != "")
            {
                this.label2.Text = Fname;
            }
            else
            {
                this.label2.Text = "您还没有选择批量测试文件，请选择";
            }
        }

        private void hideProgress()
        {
            this.progressBar1.Visible = false;
            this.label3.Visible = false;
            this.label4.Visible = false;
        }
        private void showProgress()
        {
            this.progressBar1.Visible = true;
            this.label3.Visible = true;
            this.label4.Visible = true;
        }



        // Data Type - calculate state
        public enum MyCalcState
        {
            CS_STATE_START,
            CS_STATE_READY,
            CS_STATE_FIRSTOPERAND,
            CS_STATE_OPERATOR,
            CS_STATE_SECONDOPERAND,
            CS_STATE_END
        };

        // Data Type - internal key type
        public enum MyCalcInternalKeyType
        {
            IKT_START,
            IKT_DIGIT,
            IKT_OPERATOR,
            IKT_CANCEL,
            IKT_MEMORY,
            IKT_UNKNOWN,
            IKT_END
        };

        // Data Type - internal key
        public enum MyInternalKey
        {
            IK_START,
            IK_DIGIT_START,
            IK_DIGIT_0,
            IK_DIGIT_1,
            IK_DIGIT_2,
            IK_DIGIT_3,
            IK_DIGIT_4,
            IK_DIGIT_5,
            IK_DIGIT_6,
            IK_DIGIT_7,
            IK_DIGIT_8,
            IK_DIGIT_9,
            IK_DIGIT_PERIOD,
            IK_DIGIT_END,

            IK_OPERATOR_START,
            IK_OPERATOR_SIGN,
            IK_OPERATOR_PLUS,
            IK_OPERATOR_SUB,
            IK_OPERATOR_MUL,
            IK_OPERATOR_DIV,
            IK_OPERATOR_RESULT,
            IK_OPERATOR_END,

            IK_CANCEL_START,
            IK_CANCEL_C,
            IK_CANCEL_CE,
            IK_CANCEL_END,

            IK_MEMORY_START,
            IK_MEMORY_MC,
            IK_MEMORY_MA,
            IK_MEMORY_MS,
            IK_MEMORY_MR,
            IK_MEMORY_END,

            IK_END
        };

        public enum MyCalcOperator { PLUS, SUB, MUL, DIV, SIGN };


        public MyCalcInternalKeyType g_getInternalKeyType(MyInternalKey ik)
        {
            if (ik.CompareTo(MyInternalKey.IK_DIGIT_START) > 0 && ik.CompareTo(MyInternalKey.IK_DIGIT_END) < 0)
            {
                return MyCalcInternalKeyType.IKT_DIGIT;
            }
            else if (ik.CompareTo(MyInternalKey.IK_OPERATOR_START) > 0 && ik.CompareTo(MyInternalKey.IK_OPERATOR_END) < 0)
            {
                return MyCalcInternalKeyType.IKT_OPERATOR;
            }
            else if (ik.CompareTo(MyInternalKey.IK_CANCEL_START) > 0 && ik.CompareTo(MyInternalKey.IK_CANCEL_END) < 0)
            {
                return MyCalcInternalKeyType.IKT_CANCEL;
            }
            else if (ik.CompareTo(MyInternalKey.IK_MEMORY_START) > 0 && ik.CompareTo(MyInternalKey.IK_MEMORY_END) < 0)
            {
                return MyCalcInternalKeyType.IKT_MEMORY;
            }
            else
            {
                return MyCalcInternalKeyType.IKT_UNKNOWN;
            }
        }



        // MyCalcNumber data type

        MyCalcState mycalcState;
        MyCalcNumber firstNumber;
        MyCalcNumber secondNumber;
        MyCalcNumber resultNumber;
        MyInternalKey mycalcOperator;


               //--------------------InputOutputController_Start--------------------
        int ioc_setMemoryFlagData()
        {
            this.lblMemoryFlag.Text = "M";
            return 0;
        }
        int ioc_clearMemoryFlagData()
        {
            this.lblMemoryFlag.Text = "";
            return 0;
        }
        int ioc_setMemoryFlagOverflow()
        {
            this.lblMemoryFlag.Text = "O";
            return 0;
        }
        int ioc_outputNumber(double number)
        {
            //this.txtOutBox.Text = number.ToString();
            //return 0;
            string str = number.ToString();
            //int len;
            //len = str.Length;
            //while(len>0&&str[len-1]=='0')
            //{
            //    str = str.Substring(0,len-1);
            //    len = str.Length;
            //}
            this.txtOutBox.Text = str;
            return 0;
        }

        int ioc_outputMessage(string msg)
        {
            this.txtOutBox.Text = msg;
            return 0;
        }

        public int ioc_outputText(String strText)
        {
            txtOutBox.Text = strText;
            return 0;
        }


        //--------------------InputOutputController_End--------------------


        //--------------------InternalKeyManager_Start--------------------
        int ikm_inputKey(MyInternalKey ik)
        {
            cik_inputKey(ik);
            return 0;
        }
        public int ikm_textRefreshed(String text)
        {
            ioc_outputText(text);
            return 0;
        }
        public int ikm_dataRefreshed(int number)
        {
            String str = number.ToString();
            str = str + ".";
            ioc_outputText(str);
            return 0;
        }
        public int ikm_clearAll()
        {
            initGlobal();
            return 0;
        }
        void initGlobal()
        {
            mycalcState = MyCalcState.CS_STATE_READY;
            this.txtOutBox.Text = "0.";
            firstNumber = new MyCalcNumber();
            secondNumber = new MyCalcNumber();
            resultNumber = new MyCalcNumber();
            MyInternalKey mycalcOperator;

            //firstNumber.setNumber('0');
            //secondNumber.setNumber('0');
            resultNumber.setNumber("0");
            firstNumber.setText("END");
            secondNumber.setText("END");
            mycalcOperator = MyInternalKey.IK_CANCEL_START;
        }

        //--------------------InternalKeyManager_End--------------------


        //--------------------ClassifyInternalKey_Start--------------------
        public int cik_inputKey(MyInternalKey ik)
        {
            switch (g_getInternalKeyType(ik))
            {
                case MyCalcInternalKeyType.IKT_DIGIT:
                    pik_processDigit(ik);
                    break;

                case MyCalcInternalKeyType.IKT_OPERATOR:
                    pik_processOperator(ik);
                    break;

                case MyCalcInternalKeyType.IKT_CANCEL:
                    pik_processCancel(ik);
                    break;

                case MyCalcInternalKeyType.IKT_MEMORY:
                    pik_processMemory(ik);
                    break;
            }
            return 0;

        }

        //--------------------ClassifyInternalKey_End--------------------


        //--------------------ProcessInternalKey_Start--------------------

        public int pik_processDigit(MyInternalKey ik)
        {

            int ik_digit;

            if (g_getInternalKeyType(ik) != MyCalcInternalKeyType.IKT_DIGIT)
            {
                return 1;
            }

           
            if (ik == MyInternalKey.IK_DIGIT_PERIOD)
            {
                pik_processDigitPeriod(ik);
                return 0;
            }
            ik_digit = ik - MyInternalKey.IK_DIGIT_0;

            switch (mycalcState)
            {
                case MyCalcState.CS_STATE_READY:
                    this.firstNumber.setNumber(ik_digit);
                    ikm_textRefreshed(firstNumber.OriString());

                    mycalcState = MyCalcState.CS_STATE_FIRSTOPERAND;
                    break;

                case MyCalcState.CS_STATE_FIRSTOPERAND:
                    firstNumber.appendDigit(ik_digit.ToString());
                    ikm_textRefreshed(firstNumber.OriString());
                    break;

                case MyCalcState.CS_STATE_OPERATOR:
                    secondNumber.setNumber(ik_digit);
                    ikm_textRefreshed(secondNumber.OriString());

                    mycalcState = MyCalcState.CS_STATE_SECONDOPERAND;
                    break;

                case MyCalcState.CS_STATE_SECONDOPERAND:
                    secondNumber.appendDigit(ik_digit.ToString());
                    ikm_textRefreshed(secondNumber.OriString());
                    break;
            }
            return 0;
        }

        public int pik_processDigitPeriod(MyInternalKey ik)
        {
            switch (mycalcState)
            {
                case MyCalcState.CS_STATE_READY:
                    firstNumber.setNumber("0.");
                    ikm_textRefreshed(firstNumber.OriString());

                    mycalcState = MyCalcState.CS_STATE_FIRSTOPERAND;
                    break;

                case MyCalcState.CS_STATE_FIRSTOPERAND:
                    firstNumber.appendDigit(".");
                    ikm_textRefreshed(firstNumber.OriString());
                    break;

                case MyCalcState.CS_STATE_OPERATOR:
                    secondNumber.setNumber("0.");
                    ikm_textRefreshed(secondNumber.OriString());

                    mycalcState = MyCalcState.CS_STATE_SECONDOPERAND;
                    break;

                case MyCalcState.CS_STATE_SECONDOPERAND:
                    secondNumber.appendDigit(".");
                    ikm_textRefreshed(secondNumber.OriString());
                    break;
            }
            return 0;
        }

        public int pik_processOperator(MyInternalKey ik)
        {
            //double fn, sn, rn;

            if (g_getInternalKeyType(ik) != MyCalcInternalKeyType.IKT_OPERATOR)
            {
                return 1;
            }

            if (ik == MyInternalKey.IK_OPERATOR_SIGN)
            {
                if (mycalcState == MyCalcState.CS_STATE_FIRSTOPERAND)
                {
                    firstNumber.setNumber(0 - firstNumber.getNumber());
                    ikm_textRefreshed(firstNumber.toString());
                }
                if (mycalcState == MyCalcState.CS_STATE_SECONDOPERAND)
                {
                    secondNumber.setNumber(0 - secondNumber.getNumber());
                    ikm_textRefreshed(secondNumber.toString());
                }
                if (mycalcState == MyCalcState.CS_STATE_OPERATOR)
                {
                    secondNumber.setNumber(0 - secondNumber.getNumber());
                    ikm_textRefreshed(secondNumber.toString());
                }
                if (mycalcState == MyCalcState.CS_STATE_READY)
                {
                    resultNumber.setNumber(0 - resultNumber.getNumber());
                    ikm_textRefreshed(resultNumber.toString());
                }

            }
            else
            {

                if (ik == MyInternalKey.IK_OPERATOR_RESULT)
                {
                    mycalcState = MyCalcState.CS_STATE_SECONDOPERAND;
                }
                
                switch (mycalcState)
                {
                    case MyCalcState.CS_STATE_READY:
                        if (firstNumber.getText() == "END" && secondNumber.getText() == "END")
                        {
                            firstNumber.setText(resultNumber.getText());
                            mycalcOperator = ik;
                            mycalcState = MyCalcState.CS_STATE_OPERATOR;
                        }
                        break;

                    case MyCalcState.CS_STATE_FIRSTOPERAND:
                            mycalcOperator = ik;
                            mycalcState = MyCalcState.CS_STATE_OPERATOR;
                            break;

                    case MyCalcState.CS_STATE_OPERATOR:
                        {
                            if (ik == MyInternalKey.IK_OPERATOR_RESULT && firstNumber.getText() == resultNumber.getText() && secondNumber.getText() == "END")
                            {
                                secondNumber.setNumber(firstNumber.getNumber());
                                pik_doCalculate();
                                mycalcState = MyCalcState.CS_STATE_READY;
                            }
                            else
                            {
                                mycalcOperator = ik;
                            }
                        }
                        break;

                    case MyCalcState.CS_STATE_SECONDOPERAND:
                        pik_doCalculate();
                        mycalcState = MyCalcState.CS_STATE_READY;
                        if (ik != MyInternalKey.IK_OPERATOR_RESULT)
                        {
                            firstNumber.setText(resultNumber.getText());
                            mycalcOperator = ik;
                            mycalcState = MyCalcState.CS_STATE_OPERATOR;
                        }
                        break;
                }
            }

            return 0;
        }

        public void pik_processMemory(MyInternalKey ik)
        {
            switch (ik)
            {
                case MyInternalKey.IK_MEMORY_MA:
                    {
                        memNum.setNumber(memNum.getNumber()+Convert.ToDouble(this.txtOutBox.Text));
                        this.ioc_setMemoryFlagData();                      
                    }
                    break;
                case MyInternalKey.IK_MEMORY_MS:
                    {
                        memNum.setNumber(memNum.getNumber() - Convert.ToDouble(this.txtOutBox.Text));
                        this.ioc_setMemoryFlagData();     
                    }
                    break;
                case MyInternalKey.IK_MEMORY_MC:
                    {
                        memNum.setNumber(0);
                        this.ioc_clearMemoryFlagData();
                    }
                    break;
                case MyInternalKey.IK_MEMORY_MR:
                    {
                        switch (mycalcState)
                        {
                            case MyCalcState.CS_STATE_READY:
                                {
                                    ikm_textRefreshed(memNum.toString());
                                    firstNumber.setNumber(memNum.getNumber());
                                    mycalcState = MyCalcState.CS_STATE_FIRSTOPERAND;
                                }
                                break;

                            case MyCalcState.CS_STATE_FIRSTOPERAND:
                                {
                                    ikm_textRefreshed(memNum.toString());
                                    firstNumber.setNumber(memNum.getNumber());
                                    mycalcState = MyCalcState.CS_STATE_OPERATOR;
                                }
                                break;

                            case MyCalcState.CS_STATE_OPERATOR:
                                {
                                    if (mycalcOperator == MyInternalKey.IK_CANCEL_START)
                                    {

                                    }
                                    else
                                    {
                                        ikm_textRefreshed(memNum.toString());
                                        secondNumber.setNumber(memNum.getNumber());
                                        mycalcState = MyCalcState.CS_STATE_SECONDOPERAND;
                                    }
                                }
                                break;

                            case MyCalcState.CS_STATE_SECONDOPERAND:
                                {
                                    //ikm_textRefreshed(memNum.toString());
                                    //secondNumber.setNumber(memNum.getNumber());
                                    pik_doCalculate();
                                }
                                break;
                        }
                    }
                    break;
            }
        }

        public int pik_doCalculate()
        {
            double fn, sn, rn;
            int error = 0;
            fn = 0;
            sn = 0;
            rn = 0;
            if (firstNumber.OToString() == "END" && secondNumber.OToString() == "END")
            {
                if (mycalcOperator == MyInternalKey.IK_CANCEL_START)
                {
                    this.initGlobal();
                }
                firstNumber.setText(resultNumber.getText());
                secondNumber.setText(lastSecond.getText());
                fn = firstNumber.getNumber();
                sn = secondNumber.getNumber();
                mycalcOperator = lastOperator;
                switch (mycalcOperator)
                {
                    case MyInternalKey.IK_OPERATOR_SIGN:
                        rn = 0 - fn;
                        break;
                    case MyInternalKey.IK_OPERATOR_PLUS:
                        rn = fn + sn;
                        break;

                    case MyInternalKey.IK_OPERATOR_SUB:
                        rn = fn - sn;
                        break;

                    case MyInternalKey.IK_OPERATOR_MUL:
                        rn = fn * sn;
                        break;

                    case MyInternalKey.IK_OPERATOR_DIV:
                        if (sn != 0)
                        {
                            rn = fn / sn;
                        }
                        else
                        {
                            error = 1;
                        }
                        break;

                    case MyInternalKey.IK_OPERATOR_RESULT:
                        break;

                    default:
                        break;

                }
                lastFirst.setText(firstNumber.getText());
                lastSecond.setText(secondNumber.getText());
                lastOperator = mycalcOperator;

                firstNumber.setText("END");
                secondNumber.setText("END");
                resultNumber.setNumber(rn);

                ikm_textRefreshed(resultNumber.toString());
                if (error == 1)
                {
                    ikm_textRefreshed("Error : Divide By Zero !");
                }
            }
            else
            {
                if (firstNumber.OToString() != "END" && secondNumber.OToString() == "END")
                {
                    fn = firstNumber.getNumber();
                    sn = firstNumber.getNumber();
                }

                if (firstNumber.OToString() != "END" && secondNumber.OToString() != "END" /*&& firstNumber.OToString() != resultNumber.OToString()*/)
                {
                    fn = firstNumber.getNumber();
                    sn = secondNumber.getNumber();
                }
                rn = 0.0;

                switch (mycalcOperator)
                {
                    case MyInternalKey.IK_OPERATOR_SIGN:
                        rn = 0 - fn;
                        break;
                    case MyInternalKey.IK_OPERATOR_PLUS:
                        rn = fn + sn;
                        break;

                    case MyInternalKey.IK_OPERATOR_SUB:
                        rn = fn - sn;
                        break;

                    case MyInternalKey.IK_OPERATOR_MUL:
                        rn = fn * sn;
                        break;

                    case MyInternalKey.IK_OPERATOR_DIV:
                        if (sn != 0)
                        {
                            rn = fn / sn;
                        }
                        else
                        {
                            error = 1;
                        }
                        break;

                    case MyInternalKey.IK_OPERATOR_RESULT:
                        break;

                    default:
                        break;

                }
                lastFirst.setText(firstNumber.getText());
                lastSecond.setText(secondNumber.getText());
                lastOperator = mycalcOperator;

                firstNumber.setText("END");
                secondNumber.setText("END");
                resultNumber.setNumber(rn);

                ikm_textRefreshed(resultNumber.toString());
                if (error == 1)
                {
                    ikm_textRefreshed("Error : Divide By Zero !");
                }
            }
            return 0;
        }
        public int pik_processCancel(MyInternalKey ik)
        {
            ikm_clearAll();
            return 0;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            Fname = openFileDialog1.FileName;
            if (Fname != "")
            {
                this.label2.Text = Fname;
            }
            else
            {
                this.label2.Text = "您还没有选择批量测试文件，请选择";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.groupBox1.Enabled = true;

            this.progressBar1.Value = 0;
            this.richTextBox1.Text = "";
            this.richTextBox2.Text = "";
            if (Fname != "")
            {
                string MyTxt;
                string result;
                string res;
                int behindresult = 0;
                int linetotal = 0;
                int right = 0;
                int wrong = 0;
                string num = "";

                StreamReader SF = new StreamReader(Fname, System.Text.Encoding.ASCII);
                SF.BaseStream.Seek(0, SeekOrigin.Begin);

                while (SF.Peek() != -1)
                {
                    MyTxt = SF.ReadLine();
                    lines = lines + 1;
                }
                linetotal = lines;   //测试文件总共的行数
                SF.Close();



                StreamReader MySF = new StreamReader(Fname, System.Text.Encoding.ASCII);




                //开始自动处理公式
                MySF.BaseStream.Seek(0, SeekOrigin.Begin);
                while (MySF.Peek() != -1)
                {
                    int txtlength;
                    MyTxt = MySF.ReadLine();
                    txtlength = 0;
                    txtlength=MyTxt.Length;
                    int calcend = 0;
                    for (int i = 0; i < txtlength; i++)
                    {
                        if (calcend == 0)
                        {
                            switch (MyTxt[i].ToString())
                            {
                                case "0":
                                    ikm_inputKey(MyInternalKey.IK_DIGIT_0);
                                    break;
                                case "1":
                                    ikm_inputKey(MyInternalKey.IK_DIGIT_1);
                                    break;
                                case "2":
                                    ikm_inputKey(MyInternalKey.IK_DIGIT_2);
                                    break;
                                case "3":
                                    ikm_inputKey(MyInternalKey.IK_DIGIT_3);
                                    break;
                                case "4":
                                    ikm_inputKey(MyInternalKey.IK_DIGIT_4);
                                    break;
                                case "5":
                                    ikm_inputKey(MyInternalKey.IK_DIGIT_5);
                                    break;
                                case "6":
                                    ikm_inputKey(MyInternalKey.IK_DIGIT_6);
                                    break;
                                case "7":
                                    ikm_inputKey(MyInternalKey.IK_DIGIT_7);
                                    break;
                                case "8":
                                    ikm_inputKey(MyInternalKey.IK_DIGIT_8);
                                    break;
                                case "9":
                                    ikm_inputKey(MyInternalKey.IK_DIGIT_9);
                                    break;
                                case "+":
                                    {
                                        if (pressedMR == 1)
                                        {
                                            pressedMR = 0;
                                        }
                                        ikm_inputKey(MyInternalKey.IK_OPERATOR_PLUS);
                                    }
                                    break;
                                case "-":
                                    {
                                        if (pressedMR == 1)
                                        {
                                            pressedMR = 0;
                                        }
                                        ikm_inputKey(MyInternalKey.IK_OPERATOR_SUB);
                                    }
                                    break;
                                case "*":
                                    {
                                        if (pressedMR == 1)
                                        {
                                            pressedMR = 0;
                                        }
                                        ikm_inputKey(MyInternalKey.IK_OPERATOR_MUL);
                                    }
                                    break;
                                case "/":
                                    {
                                        if (pressedMR == 1)
                                        {
                                            pressedMR = 0;
                                        }
                                        ikm_inputKey(MyInternalKey.IK_OPERATOR_DIV);
                                    }
                                    break;
                                case "=":
                                    {
                                        if (pressedMR == 1)
                                        {
                                            pressedMR = 0;
                                        }
                                        ikm_inputKey(MyInternalKey.IK_OPERATOR_RESULT);
                                        if (i == MyTxt.LastIndexOf("="))
                                        {
                                            calcend = 1;
                                            behindresult = i;
                                        }
                                        //MessageBox.Show(behindresult.ToString());
                                        //MessageBox.Show(MyTxt.Length.ToString());
                                    }
                                    break;
                                case "C":
                                    {
                                        ikm_inputKey(MyInternalKey.IK_CANCEL_CE);
                                    }
                                    break;
                                case "A":
                                    {
                                        ikm_inputKey(MyInternalKey.IK_MEMORY_MA);
                                    }
                                    break;
                                case "S":
                                    {
                                        ikm_inputKey(MyInternalKey.IK_MEMORY_MS);
                                    }
                                    break;
                                case "R":
                                    {
                                        ikm_inputKey(MyInternalKey.IK_MEMORY_MR);
                                    }
                                    break;
                                case "M":
                                    {
                                        ikm_inputKey(MyInternalKey.IK_MEMORY_MC);
                                    }
                                    break;
                                case "E":
                                    {
                                        ikm_inputKey(MyInternalKey.IK_OPERATOR_SIGN);
                                    }
                                    break;
                                case ".":
                                    {
                                        ikm_inputKey(MyInternalKey.IK_DIGIT_PERIOD);
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }

                     }
                     result = MyTxt;
                     result = result.Substring(behindresult + 1, MyTxt.Length - 1 - behindresult);
                     //MessageBox.Show(result);
                     res = this.txtOutBox.Text;

                     if (res.IndexOf('.') == res.Length-1)
                     {
                         //结果不是小数，需要除去小数点
                        res=res.Substring(0, this.txtOutBox.Text.Length - 1);
                     }
                     else
                     {
                         //结果中带小数点，是小数

                     }

                     if (res== result)
                     {
                         this.richTextBox1.Text += MyTxt + "\r";
                         right++;

                         this.progressBar1.Value = (int)((double)(((double)((double)wrong + right) / linetotal) * 100) / 1);
                         //MessageBox.Show(Convert.ToString(this.progressBar1.Value));
                         this.label3.Text = Convert.ToString(this.progressBar1.Value);                     
                         
                         
                     }
                     else
                     {
                         this.richTextBox2.Text += MyTxt + "\r";
                         wrong++;

                         this.progressBar1.Value = (int)((double)(((double)((double)wrong + right) / linetotal) * 100) / 1);
                         this.label3.Text = Convert.ToString(this.progressBar1.Value);  
                
                     }
                }
                MessageBox.Show("一共有"+linetotal.ToString()+"条测试用例 : "+"通过测试的"+right.ToString()+"条，"+"未通过测试的"+wrong.ToString()+"条。");
                
                MySF.Close();
                lines = 0;
            }
            else
            {
                //请先选择文件
                MessageBox.Show("对不起，您还没有选择批量测试文件，请先选择再进行计算", "Sorry:");
            }
        }

        
        //--------------------ProcessInternalKey_End--------------------

    






    }
}