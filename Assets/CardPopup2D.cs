using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPopup2D : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 1f;
    [SerializeField]
    private float centeringSpeed = 4f;
    [SerializeField]
    private bool singleScene;

    private Rigidbody rbody;
    private bool isFalling;
    private Vector3 cardFallRotation;
    private bool fallToZero;
    private float startZPos,startXPos,startYPos;
    public GameObject popupcard;
    private UnityEngine.UI.Text popupcard_title,popupcard_card;
    private List<string> isi_materi = new List<string>();
    private List<string> title_materi = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        rbody.useGravity = false;
        startZPos = transform.position.z;
        startXPos = transform.position.x;
        startYPos = transform.position.y;   
        destroy_card(); 
        inisialisasi_materi();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFalling)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(cardFallRotation), Time.deltaTime * rotationSpeed);
        }

        ///This conditional makes the popup fall nicely into place.		
        if (fallToZero)
        {
            fallToZero = false;
            transform.position = Vector3.Lerp(transform.position, new Vector3(0, 0, startZPos), Time.deltaTime * centeringSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(Vector3.zero), Time.deltaTime * centeringSpeed);
            if (Vector3.Distance(transform.position, new Vector3(0, 0, startZPos)) < 0.0025f)
            {
                transform.position = new Vector3(startXPos, startYPos, startZPos);
                fallToZero = false;
            }
        }

        ///This is totally unnecessary.
        if (transform.position.y < -300)
        {
            isFalling = false;
            rbody.useGravity = false;
            rbody.velocity = Vector3.zero;
            transform.position = new Vector3(0, 8, startZPos);
            if (singleScene)
            {
                CardEnter();
            }else
            {
                destroy_card();
            }
        }
    }

    public void CardEnter()
    {
        fallToZero = true;
    }

    ///A negative fallRotation will result in the card turning clockwise, while a positive fallRotation makes the card turn counterclockwise.
    public void CardFallAway(float fallRotation)
    {
        rbody.useGravity = true;
        isFalling = true;
        cardFallRotation = new Vector3(0, 0, fallRotation);
    }

    void destroy_card()
    {
        //Destroy(destro.gameObject,0);
        popupcard.SetActive(false);
    }

    void restore()
    {
        transform.position = new Vector3(startXPos, startYPos, startZPos);
    }

    public void view_card(int index)
    {
        Debug.Log("VIEW CARD CLICK");
        restore();
        popupcard.SetActive(true);
        GameObject popupcard_title_init = GameObject.Find("Canvas/Popup_Card/Card/Title_text");
        popupcard_title = popupcard_title_init.GetComponent<UnityEngine.UI.Text>();
        GameObject popupcard_card_init = GameObject.Find("Canvas/Popup_Card/Card/Card_text");
        popupcard_card = popupcard_card_init.GetComponent<UnityEngine.UI.Text>();
        popupcard_title.text = title_materi[index];
        popupcard_card.text = isi_materi[index];
    }

    void inisialisasi_materi()
    {
        isi_materi.Add("Badan sel adalah bagian dari jaringan yang terbesar. Didalam badan sel terdapat nucleus yaitu inti sel jaringan saraf. Bagian ini berfungsi sebagai penerima impus atau rangsangan dari sitoplasma bercabang menuju akson."); //cell_body
        isi_materi.Add("Selubung Mielin adalah lapisan fosfolipid yang membungkus akson secara konsentrik"); //myelin
        isi_materi.Add("Dendrit adalah bagian saraf yang sekumpulan serabut sel saraf pendek yang bercabang-cabang halus dan merupakan perluasan dari badan sel. Bagian ini berfungsi sebagai penerima impuls dan menyampaikan impuls yang diterimanya menuju badan sel."); //dendrite
        isi_materi.Add("Bagian sel safar sinapsis adalah ujung akson berfungsi untuk meneruskan impuls menuju ke neuron lainnya. Sinapsis dari satu neuron akan terhubung dengan dendrit dari neuron lainnya."); //sinapsis
        isi_materi.Add("selubung Mielin adalah lapisan fosfolipid yang membungkus akson secara konsentrik"); //akson
        isi_materi.Add("Sel schwann adalah sel penyokong akson yang berfungsi menyediakan suplai makanan bagi metabolisme akson dan membantu regenerasi akson"); //sell_schawann
        isi_materi.Add("Bagian jaringan safar inti sel atau biasa di sebut dengan nucleus berfungsi sebagai regulator dari seluruh aktivitas sel saraf. Inti sel berada di dalam badan sel, dan mengambang di antara sitoplasma."); //nukleus
        title_materi.Add("Cell Body");
        title_materi.Add("Selubung Mielin");
        title_materi.Add("Dendrite");
        title_materi.Add("Sinapsis");
        title_materi.Add("Akson");
        title_materi.Add("Sel Schawann");
        title_materi.Add("Nukleus");
    }

    
}
