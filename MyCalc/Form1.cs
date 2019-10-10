using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyCalc
{
    partial class Form1 : Form
    {
        double memory=0;
        int pressedMR = 0;
        MyCalcNumber memNum = new MyCalcNumber();
        MyCalcNumber lastFirst = new MyCalcNumber();
        MyCalcNumber lastSecond = new MyCalcNumber();
        MyInternalKey lastOperator = new MyInternalKey();

        public Form1()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            initGlobal();
            memNum.setNumber("0");
            lastFirst.setNumber("0");
            lastSecond.setNumber("0");
            lastOperator = MyInternalKey.IK_OPERATOR_START;
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
            if (ik.CompareTo(MyInternalKey.IK_DIGIT_START) > 0&& ik.CompareTo(MyInternalKey.IK_DIGIT_END) < 0)
            {
                return MyCalcInternalKeyType.IKT_DIGIT;
            }
            else if (ik.CompareTo(MyInternalKey.IK_OPERATOR_START) > 0&& ik.CompareTo(MyInternalKey.IK_OPERATOR_END) < 0)
            {
                return MyCalcInternalKeyType.IKT_OPERATOR;
            }
            else if (ik.CompareTo(MyInternalKey.IK_CANCEL_START) > 0&& ik.CompareTo(MyInternalKey.IK_CANCEL_END) < 0)
            {
                return MyCalcInternalKeyType.IKT_CANCEL;
            }
            else if (ik.CompareTo(MyInternalKey.IK_MEMORY_START) > 0&& ik.CompareTo(MyInternalKey.IK_MEMORY_END) < 0)
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




        private void 打开OToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void 关于MyCalclatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutMyCalc a = new AboutMyCalc();
            a.ShowDialog();
        }
        private void 测批量测试用例测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 fm2 = new Form2();
            fm2.ShowDialog();
        }



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

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "D0":
                    ikm_inputKey(MyInternalKey.IK_DIGIT_0);
                    break;
                case "D1":
                    ikm_inputKey(MyInternalKey.IK_DIGIT_1);
                    break;
                case "D2":
                    ikm_inputKey(MyInternalKey.IK_DIGIT_2);
                    break;
                case "D3":
                    ikm_inputKey(MyInternalKey.IK_DIGIT_3);
                    break;
                case "D4":
                    ikm_inputKey(MyInternalKey.IK_DIGIT_4);
                    break;
                case "D5":
                    ikm_inputKey(MyInternalKey.IK_DIGIT_5);
                    break;
                case "D6":
                    ikm_inputKey(MyInternalKey.IK_DIGIT_6);
                    break;
                case "D7":
                    ikm_inputKey(MyInternalKey.IK_DIGIT_7);
                    break;
                case "D8":
                    ikm_inputKey(MyInternalKey.IK_DIGIT_8);
                    break;
                case "D9":
                    ikm_inputKey(MyInternalKey.IK_DIGIT_9);
                    break;
                case "Oemplus":
                    ikm_inputKey(MyInternalKey.IK_OPERATOR_PLUS);
                    break;
                case "Oemminus":
                    ikm_inputKey(MyInternalKey.IK_OPERATOR_SUB);
                    break;
                case "OemPeriod":
                    ikm_inputKey(MyInternalKey.IK_DIGIT_PERIOD);
                    break;
                case "R":
                    ikm_inputKey(MyInternalKey.IK_OPERATOR_RESULT);
                    break;
            }
        }

        private void btnKey0_Click(object sender, EventArgs e)
        {
            ikm_inputKey(MyInternalKey.IK_DIGIT_0);
        }
        private void btnKey1_Click(object sender, EventArgs e)
        {
            ikm_inputKey(MyInternalKey.IK_DIGIT_1);
        }
        private void btnKey2_Click(object sender, EventArgs e)
        {
            ikm_inputKey(MyInternalKey.IK_DIGIT_2);
        }

        private void btnKey3_Click(object sender, EventArgs e)
        {
            ikm_inputKey(MyInternalKey.IK_DIGIT_3);
        }

        private void btnKey4_Click(object sender, EventArgs e)
        {
            ikm_inputKey(MyInternalKey.IK_DIGIT_4);
        }

        private void btnKey5_Click(object sender, EventArgs e)
        {
            ikm_inputKey(MyInternalKey.IK_DIGIT_5);
        }

        private void btnKey6_Click(object sender, EventArgs e)
        {
            ikm_inputKey(MyInternalKey.IK_DIGIT_6);
        }

        private void btnKey7_Click(object sender, EventArgs e)
        {
            ikm_inputKey(MyInternalKey.IK_DIGIT_7);
        }

        private void btnKey8_Click(object sender, EventArgs e)
        {
            ikm_inputKey(MyInternalKey.IK_DIGIT_8);
        }

        private void btnKey9_Click(object sender, EventArgs e)
        {
            ikm_inputKey(MyInternalKey.IK_DIGIT_9);
        }

        private void btnKeySign_Click(object sender, EventArgs e)
        {
            ikm_inputKey(MyInternalKey.IK_OPERATOR_SIGN);
        }

        private void btnKeyPeriod_Click(object sender, EventArgs e)
        {
            ikm_inputKey(MyInternalKey.IK_DIGIT_PERIOD);
        }

        private void btnKeyPlus_Click(object sender, EventArgs e)
        {
            if (pressedMR == 1)
            {
                pressedMR = 0;
            }
            ikm_inputKey(MyInternalKey.IK_OPERATOR_PLUS);
        }

        private void btnKeySub_Click(object sender, EventArgs e)
        {
            if (pressedMR == 1)
            {
                pressedMR = 0;
            }
            ikm_inputKey(MyInternalKey.IK_OPERATOR_SUB);
        }

        private void btnKeyMul_Click(object sender, EventArgs e)
        {
            if (pressedMR == 1)
            {
                pressedMR = 0;
            }
            ikm_inputKey(MyInternalKey.IK_OPERATOR_MUL);
        }

        private void btnKeyDiv_Click(object sender, EventArgs e)
        {
            if (pressedMR == 1)
            {
                pressedMR = 0;
            }
            ikm_inputKey(MyInternalKey.IK_OPERATOR_DIV);
        }

        private void btnKeyResult_Click(object sender, EventArgs e)
        {
            if (pressedMR == 1)
            {
                pressedMR = 0;
            }
            ikm_inputKey(MyInternalKey.IK_OPERATOR_RESULT);
        }

        private void btnKeyAC_Click(object sender, EventArgs e)
        {
                ikm_inputKey(MyInternalKey.IK_CANCEL_CE);
        }

        private void btnKeyMC_Click(object sender, EventArgs e)
        {
            ikm_inputKey(MyInternalKey.IK_MEMORY_MC);
        }

        private void btnKeyMA_Click(object sender, EventArgs e)
        {
            ikm_inputKey(MyInternalKey.IK_MEMORY_MA);
        }

        private void btnKeyMS_Click(object sender, EventArgs e)
        {
            ikm_inputKey(MyInternalKey.IK_MEMORY_MS);
        }

        private void btnKeyMR_Click(object sender, EventArgs e)
        {
            ikm_inputKey(MyInternalKey.IK_MEMORY_MR);
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
            pressedMR = 0;
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
                        if (pressedMR == 0)
                        {
                            pressedMR = 1;
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
                                        ikm_textRefreshed(memNum.toString());
                                        secondNumber.setNumber(memNum.getNumber());
                                        mycalcState = MyCalcState.CS_STATE_SECONDOPERAND;
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
                    }
                    break;
            }
        }

        public int pik_doCalculate()
        {
            try
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
            }
            catch
            {
                this.initGlobal();
            }
            return 0;
        }
    
        public int pik_processCancel(MyInternalKey ik)
        {
            ikm_clearAll();
            return 0;
        }









        //--------------------ProcessInternalKey_End--------------------

    }

    public class MyCalcNumber
    {
        private String strNumber;
        private int length;

        public MyCalcNumber()
        {
            strNumber = "";
            length = 8;
        }

        public String toString()
        {
            //return strNumber;
            String str = strNumber;
            int len;
            
            if (str.IndexOf('.') < 0)
            {
                str = str + '.';
            }
            else
            {
                len = str.Length;
                while (len > 0 && str[len - 1] == '0')
                {
                    len--;
                }
                str = str.Substring(0, len);
            }
            return str;
        }

        public String OriString()
        {
            //return strNumber;
            String str = strNumber;
            int len;

            if (str.IndexOf('.') < 0)
            {
                str = str + '.';
            }

            return str;
        }

        public String OToString()
        {
            return strNumber;
        }

        public int setText(String text)
        {
            strNumber = text;
            return 0;
        }

        public string getText()
        {
            string txt;
            txt=strNumber;
            return txt;
        }

        public int setNumber(String number)
        {
            strNumber = number;
            return 0;
        }

        //public int setNumber(int number)
        //{
        //    strNumber = number.ToString();
        //    return 0;
        //}

        public double getNumber()
        {
            double num=0;
            num = Convert.ToDouble(strNumber);
            return num;
        }

        public int setNumber(double number)
        {
            strNumber = number.ToString();
            return 0;
        }

        public int appendDigit(String digit)
        {
            int len;
            if (strNumber.Length < 8)
            {

                if (digit == ".")
                {
                    if (strNumber.IndexOf(".") >= 0)
                    {
                        return 1;
                    }

                    strNumber = strNumber + digit;
                    return 0;
                }

                //if (strNumber.IndexOf(".") >= 0) ;

                strNumber = strNumber + digit;
            }
            return 0;
        }
    }

}