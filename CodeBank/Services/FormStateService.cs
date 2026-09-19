using System.Windows.Forms;

namespace CodeBank.Services
{
    public static class FormStateService
    {
        public static DialogResult ConfirmDiscardChanges()
        {
            return MessageBox.Show(
                "تغییرات ذخیره‌نشده وجود دارد. آیا می‌خواهید ابتدا آن‌ها را ذخیره کنید؟",
                "تغییرات ذخیره‌نشده",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Warning);
        }

        public static bool ConfirmDelete()
        {
            return MessageBox.Show(
                "آیا از حذف این رکورد مطمئن هستید؟ این عملیات قابل بازگشت نیست.",
                "تأیید حذف",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes;
        }
    }
}
