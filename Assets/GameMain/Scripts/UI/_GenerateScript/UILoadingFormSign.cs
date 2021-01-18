// 此文件由工具自动生成，请勿直接修改。
// 生成时间：2021-01-18 13:46:28.290
//------------------------------------------------------------

namespace Akari
{
    public class UILoadingFormSign : BasePanel
    {
		//---UI---
		protected UnityEngine.UI.Image imgProgress = null;
		
		
		public void InitUIData()
        {

            ReferenceCollector rc = rootGo.GetComponent<ReferenceCollector>();
			
            imgProgress = rc.Get<UnityEngine.UI.Image>("imgProgress");
			
        }
    }
}
