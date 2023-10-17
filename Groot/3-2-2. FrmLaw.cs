using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Groot
{
    public partial class FrmLaw : Form
    {
        public FrmLaw()
        {
            InitializeComponent();
            this.richTextBox1.Text = "媒合人才服務使用條款\r\n\r\n1. 服務概述\r\n\r\n1.1 此服務（以下簡稱“本服務”）由[您的公司名稱]（以下簡稱“我們”或“平台”）提供，旨在媒合求職者和潛在雇主。\r\n\r\n2. 會員註冊\r\n\r\n2.1 所有使用本服務的會員（以下簡稱“會員”）必須遵守本條款。\r\n\r\n2.2 會員需要提供準確、完整的個人信息，包括履歷和求職要求。\r\n\r\n3. 個人資訊\r\n\r\n3.1 會員同意我們可以存儲和處理其個人資訊，用於提供本服務。\r\n\r\n3.2 會員的個人資訊將根據我們的隱私政策來處理，請參閱[隱私政策鏈接]以獲取更多信息。\r\n\r\n4. 求職流程\r\n\r\n4.1 本服務將媒合求職者與潛在雇主。會員同意使用本服務時應遵循相關流程和要求。\r\n\r\n5. 責任免責\r\n\r\n5.1 我們不對因會員使用本服務而導致的任何損失或損害承擔責任。\r\n\r\n6. 帳戶終止\r\n\r\n6.1 我們保留權利，在發現會員違反本條款時，終止或限制其帳戶的權利。\r\n\r\n7. 修訂\r\n\r\n7.1 我們保留權利隨時修改本條款。任何修改將在我們的平台上發布，並在生效前提前通知會員。\r\n\r\n8. 法律適用\r\n\r\n8.1 本條款受到[法律適用的法律管轄機構]法律的管轄。\r\n\r\n9. 整體協議\r\n\r\n9.1 本條款代表了會員和我們之間的整體協議，並取代所有以前的口頭或書面協議。\r\n\r\n10. 同意\r\n\r\n10.1 通過註冊為我們的會員，您表示您已閱讀、理解並同意遵守本條款。";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
