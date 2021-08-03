using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dev
{
    public partial class Form1 : Form
    {
        private float CurrentFontSize { get; set; }

        public Form1()
        {
            InitializeComponent();

            this.NewFileMenuItem.Click += this.NewFileMenuItem_Click; // 새로 만들기
            this.OpenFileMenuItem.Click += this.OpenFileMenuItem_Click; // 열기
            this.SaveFileMenuItem.Click += this.SaveFileMenuItem_Click; // 저장
            this.PageSettingMenuItem.Click += this.PageSettingMenuItem_Click; // 페이지 설정
            this.PrintMenuItem.Click += this.PrintMenuItem_Click; // 인쇄
            this.ExitMenuItem.Click += this.ExitMenuItem_Click; // 끝내기
            this.CutMenuItem.Click += this.CutMenuItem_Click; // 잘라내기
            this.CopyMenuItem.Click += this.CopyMenuItem_Click; // 복사
            this.PasteMenuItem.Click += this.PasteMenuItem_Click; // 붙여넣기
            this.DeleteMenuItem.Click += this.DeleteMenuItem_Click; // 삭제
            this.FindMenuItem.Click += this.FindMenuItem_Click; // 찾기
            this.SelectAllMenuItem.Click += this.SelectAllMenuItem_Click; // 모두 선택
            this.DateTimeMenuItem.Click += this.DateTimeMenuItem_Click; // 시각/날짜
            this.FontMenuItem.Click += this.FontMenuItem_Click; // 글꼴
            this.IncreaseFontMenuItem.Click += this.IncreaseFontMenuItem_Click; // 확대하기
            this.DecreaseFontMenuItem.Click += this.DecreaseFontMenuItem_Click; // 축소하기
        }

        /// <summary>
        /// 축소하기 메뉴 클릭 시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DecreaseFontMenuItem_Click(object sender, EventArgs e)
        {
            CurrentFontSize = memoEdit.Font.Size;
            CurrentFontSize -= 2;
            memoEdit.Font = new Font(memoEdit.Font.Name, CurrentFontSize, memoEdit.Font.Style, memoEdit.Font.Unit);
        }

        /// <summary>
        /// 확대하기 메뉴 클릭 시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IncreaseFontMenuItem_Click(object sender, EventArgs e)
        {
            CurrentFontSize = memoEdit.Font.Size;
            CurrentFontSize += 2;
            memoEdit.Font = new Font(memoEdit.Font.Name, CurrentFontSize, memoEdit.Font.Style, memoEdit.Font.Unit);
        }

        /// <summary>
        /// 시각/날짜 클릭 시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateTimeMenuItem_Click(object sender, EventArgs e)
        {
            //string daynight = System.DateTime.Now.ToString("tt");
            //string hour = System.DateTime.Now.ToString("hh");
            //string minute = System.DateTime.Now.ToString("mm");
            //string second = System.DateTime.Now.ToString("ss");
            //string year = System.DateTime.Now.ToString("yyyy");
            //string month = System.DateTime.Now.ToString("MM");
            //string day = System.DateTime.Now.ToString("dd");

            memoEdit.Text = DateTime.Now.ToString("tt hh:mm yyyy-MM-dd");
        }

        /// <summary>
        /// 모두 선택 클릭 시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectAllMenuItem_Click(object sender, EventArgs e)
        {
            memoEdit.SelectAll();
        }

        /// <summary>
        /// 글꼴 메뉴 클릭 시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FontMenuItem_Click(object sender, EventArgs e)
        {
            using (FontDialog dialog = new FontDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    memoEdit.Font = dialog.Font;
                }
            }
        }

        /// <summary>
        /// 찾기 메뉴 클릭 시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 삭제 메뉴 클릭 시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            memoEdit.SelectedText = "";
        }

        /// <summary>
        /// 붙여넣기 메뉴 클릭 시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasteMenuItem_Click(object sender, EventArgs e)
        {
            memoEdit.Paste();
        }

        /// <summary>
        /// 복사 메뉴 클릭 시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyMenuItem_Click(object sender, EventArgs e)
        {
            memoEdit.Copy();
        }

        /// <summary>
        /// 잘라내기 메뉴 클릭 시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CutMenuItem_Click(object sender, EventArgs e)
        {
            memoEdit.Cut();
        }

        /// <summary>
        /// 끌내기 메뉴 클릭 시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        /// <summary>
        /// 인쇄 메뉴 클릭 시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintMenuItem_Click(object sender, EventArgs e)
        {
            using (PrintDialog dialog = new PrintDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    
                }
            }
        }

        /// <summary>
        /// 페이지 설정 메뉴 클릭 시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PageSettingMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 저장 메뉴 클릭 시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveFileMenuItem_Click(object sender, EventArgs e)
        {
            using (XtraSaveFileDialog dialog = new XtraSaveFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(dialog.FileName, memoEdit.Text);

                    //fileName = dialog.FileName.ToString();
                }
            }
        }

        /// <summary>
        /// 파일 열기 메뉴 클릭 시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFileMenuItem_Click(object sender, EventArgs e)
        {
            using (XtraOpenFileDialog dialog = new XtraOpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    File.ReadAllText(dialog.FileName);
                }
            }
        }

        /// <summary>
        /// 새로운 파일 만들기 클릭 시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewFileMenuItem_Click(object sender, EventArgs e)
        {
            if (memoEdit.Text.Length != 0)
            {
                using (XtraSaveFileDialog dialog = new XtraSaveFileDialog())
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        //fileName = dialog.FileName.ToString();
                    }

                    memoEdit.EditValue = "";
                }
            }
        }
    }
}
