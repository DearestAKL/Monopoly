// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2021-01-17 14:31:43.831
//------------------------------------------------------------

namespace Akari
{
    public class UIMainMenuFormSign : BasePanel
    {
		//---UI---
		public UnityEngine.UI.Button btnStart = null;
		public UnityEngine.UI.Button btnContinue = null;
		public UnityEngine.UI.Button btnMod = null;
		public UnityEngine.UI.Button btnSetting = null;
		
		
		public void InitUIData()
        {

            ReferenceCollector rc = rootGo.GetComponent<ReferenceCollector>();
			
            btnStart = rc.Get<UnityEngine.UI.Button>("btnStart");
			btnContinue = rc.Get<UnityEngine.UI.Button>("btnContinue");
			btnMod = rc.Get<UnityEngine.UI.Button>("btnMod");
			btnSetting = rc.Get<UnityEngine.UI.Button>("btnSetting");
			
        }
    }
}
