// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2021-01-18 13:41:50.086
//------------------------------------------------------------

namespace Akari
{
    public class UIMainMenuFormSign : BasePanel
    {
		//---UI---
		protected UnityEngine.UI.Button btnStart = null;
		protected UnityEngine.UI.Button btnContinue = null;
		protected UnityEngine.UI.Button btnMod = null;
		protected UnityEngine.UI.Button btnSetting = null;
		
		
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
