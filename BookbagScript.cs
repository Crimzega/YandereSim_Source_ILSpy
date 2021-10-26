using UnityEngine;

public class BookbagScript : MonoBehaviour
{
	public PickUpScript ConcealedPickup;

	public Rigidbody MyRigidbody;

	public PromptScript Prompt;

	public Texture EightiesBookBagTexture;

	public Mesh EightiesBookBag;

	public Renderer MyRenderer;

	public MeshFilter MyMesh;

	private void Start()
	{
		MyRigidbody.useGravity = false;
		MyRigidbody.isKinematic = true;
		if (GameGlobals.Eighties)
		{
			MyRenderer.material.mainTexture = EightiesBookBagTexture;
			MyMesh.mesh = EightiesBookBag;
		}
	}

	private void Update()
	{
		if (Prompt.Yandere.PickUp != null || ConcealedPickup != null)
		{
			Prompt.HideButton[0] = false;
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Prompt.Circle[0].fillAmount = 1f;
				if (ConcealedPickup == null)
				{
					ConcealedPickup = Prompt.Yandere.PickUp;
					ConcealedPickup.Drop();
					ConcealedPickup.gameObject.SetActive(value: false);
					Prompt.Label[0].text = "     Retrieve " + ConcealedPickup.name;
				}
				else
				{
					ConcealedPickup.transform.position = base.transform.position;
					ConcealedPickup.gameObject.SetActive(value: true);
					ConcealedPickup = null;
					Prompt.Label[0].text = "     Conceal Item";
				}
			}
		}
		else
		{
			Prompt.HideButton[0] = true;
		}
		if (Prompt.Circle[3].fillAmount == 0f)
		{
			Prompt.Yandere.Bookbag = this;
			base.transform.parent = Prompt.Yandere.BookBagParent;
			base.transform.localPosition = new Vector3(0f, 0f, 0f);
			base.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			base.transform.localScale = new Vector3(1f, 1f, 1f);
			Prompt.MyCollider.enabled = false;
			MyRigidbody.useGravity = false;
			MyRigidbody.isKinematic = true;
			Prompt.Hide();
			Prompt.enabled = false;
			base.enabled = true;
		}
	}

	public void Drop()
	{
		Prompt.Yandere.Bookbag = null;
		base.transform.parent = null;
		Prompt.MyCollider.enabled = true;
		MyRigidbody.useGravity = true;
		MyRigidbody.isKinematic = false;
		Prompt.enabled = true;
		base.enabled = true;
	}
}
