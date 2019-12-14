using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testTouch : MonoBehaviour
{
    private GameObject cell_body,myelin,dendrite,sinapsis,akson,sell_schawann,nukleus;
    private GameObject popupcard;
    private UnityEngine.UI.Text popupcard_title,popupcard_card;
    private GameObject cell_body_label,myelin_label,dendrite_label,sinapsis_label,akson_label,sell_schawann_label,nukleus_label;
    private LineRenderer cell_body_line,myelin_line,dendrite_line,sinapsis_line,akson_line,sell_schawann_line,nukleus_line;
    public bool detail_luar = false, detail_dalam = false;
    private List<string> isi_materi = new List<string>();
    private List<string> title_materi = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        load_data();
        inisialisasi_materi();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("TESTTT");
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit Hit;
            if(Physics.Raycast(ray, out Hit))
            {
                if(Hit.transform.name == "btn_detail_luar")
                {
                    detail_luar = true;
                    detail_dalam = false;
                }else if(Hit.transform.name == "btn_detail_dalam")
                {
                    detail_luar = false;
                    detail_dalam = true;
                }
                switch (Hit.transform.name)
                {
                    case "cell_body_box":
                        detail_materi(0);
                        break;
                    case "myelin_box":
                        detail_materi(1);
                        break;
                    case "dendrite_box":
                        detail_materi(2);
                        break;
                    case "sinapsis_box":
                        detail_materi(3);
                        break;
                    case "akson_box":
                        detail_materi(4);
                        break;
                    case "sell_schawann_box":
                        detail_materi(5);
                        break;
                    case "nukleus_box":
                        detail_materi(6);
                        break;
                }
            } 
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray_1 = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hits;
            if(Physics.Raycast(ray_1, out hits))
            {
                Debug.Log(hits.collider.name);
                if(hits.transform.name == "btn_detail_luar")
                {
                    detail_luar = true;
                    detail_dalam = false;
                }else if(hits.transform.name == "btn_detail_dalam")
                {
                    detail_luar = false;
                    detail_dalam = true;
                }
                switch (hits.transform.name)
                {
                    case "cell_body_box":
                        detail_materi(0);
                        break;
                    case "myelin_box":
                        detail_materi(1);
                        break;
                    case "dendrite_box":
                        detail_materi(2);
                        break;
                    case "sinapsis_box":
                        detail_materi(3);
                        break;
                    case "akson_box":
                        detail_materi(4);
                        break;
                    case "sell_schawann_box":
                        detail_materi(5);
                        break;
                    case "nukleus_box":
                        detail_materi(6);
                        break;
                }
            }
        }
        if(detail_luar == true)
        {
            if(cell_body != null && cell_body_label != null)
            {
                cell_body_line.SetPosition(0, cell_body.transform.position);
                cell_body_line.SetPosition(1, cell_body_label.transform.position);
            }
            if(myelin != null && myelin_label != null)
            {
                Debug.Log("MYELIN");
                myelin_line.SetPosition(0, myelin.transform.position);
                myelin_line.SetPosition(1, myelin_label.transform.position);
            }
            if(dendrite != null && dendrite_label != null)
            {
                dendrite_line.SetPosition(0, dendrite.transform.position);
                dendrite_line.SetPosition(1, dendrite_label.transform.position);
            }
            if(sinapsis != null && sinapsis_label != null)
            {
                sinapsis_line.SetPosition(0, sinapsis.transform.position);
                sinapsis_line.SetPosition(1, sinapsis_label.transform.position);
            }
        }
        else if(detail_dalam == true)
        {
            if(akson != null && akson_label != null)
            {
                akson_line.SetPosition(0, akson.transform.position);
                akson_line.SetPosition(1, akson_label.transform.position);
            }
            if(sell_schawann != null && sell_schawann_label != null)
            {
                sell_schawann_line.SetPosition(0, sell_schawann.transform.position);
                sell_schawann_line.SetPosition(1, sell_schawann_label.transform.position);
            }
            if(nukleus != null && nukleus_label != null)
            {
                nukleus_line.SetPosition(0, nukleus.transform.position);
                nukleus_line.SetPosition(1, nukleus_label.transform.position);
            }
        }
        //falling_card();
        tracking_image("/ImageTarget");
    }

    /*
    * -------------------------------------------- KETERANGAN -------------------------------------------------
    * NAMA : void inisialisasi_materi()
    * DESKRIPSI:
    * Fungsi yang digunakan untuk menginisialisasi data isi materi dan judul materi
    * STATUS:
    * Done
    * ----------------------------------------------------------------------------------------------------------
    */
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

    /*
    * -------------------------------------------- KETERANGAN -------------------------------------------------
    * NAMA : public void detail_materi(int index)
    * DESKRIPSI:
    * Fungsi yang digunakan untuk menampilkan popup card dari materi
    * Parameter:
    * int index = "NILAI DARI INDEX DARI VARIABEL isi_materi DAN title_materi"
    * STATUS:
    * Done
    * ----------------------------------------------------------------------------------------------------------
    */
    public void detail_materi(int index)
    {
        close_card();
        popupcard.SetActive(true);
        popupcard_title.text = title_materi[index];
        popupcard_card.text = isi_materi[index];
    }

    /*
    * -------------------------------------------- KETERANGAN -------------------------------------------------
    * NAMA : void load_data()
    * DESKRIPSI:
    * Fungsi yang digunakan untuk memanggil selurh object yang ada pada object ImageTarget
    * STATUS:
    * Done
    * ----------------------------------------------------------------------------------------------------------
    */
    void load_data()
    {
        /*
        * Bagian Luar
        */
        cell_body = GameObject.Find("/ImageTarget/neuron/Nulo_/cell_body");
        cell_body_label = GameObject.Find("/ImageTarget/cell_body_detail/cell_body_box");
        myelin = GameObject.Find("/ImageTarget/neuron/Nulo_/myelin/Cápsula_4");
        myelin_label = GameObject.Find("/ImageTarget/myelin_detail/myelin_box");
        dendrite = GameObject.Find("/ImageTarget/neuron/Nulo_/dendrite/Nulo__2_12/Recorrido_15/Redondeado_851");
        dendrite_label = GameObject.Find("/ImageTarget/dendrite_detail/dendrite_box");
        sinapsis = GameObject.Find("/ImageTarget/neuron/Nulo_/sinapsis/Redondeado");
        sinapsis_label = GameObject.Find("/ImageTarget/sinapsis_detail/sinapsis_box");
        disable_object_luar();
        
        /*
        * Bagian Dalam
        */
        akson = GameObject.Find("/ImageTarget/neuron/Nulo_/akson");
        akson_label = GameObject.Find("/ImageTarget/akson_detail/akson_box");
        sell_schawann = GameObject.Find("/ImageTarget/neuron/Nulo_/sell_schawann_group/sell_schwann_7");
        sell_schawann_label = GameObject.Find("/ImageTarget/sell_schawann_detail/sell_schawann_box");
        nukleus = GameObject.Find("/ImageTarget/neuron/Nulo_/cell_body/nukleus");
        nukleus_label = GameObject.Find("/ImageTarget/nukleus_detail/nukleus_box");
        disable_object_dalam();

        /*
        * Detail Materi
        */
        popupcard = GameObject.Find("Canvas/Popup_Card");
        GameObject popupcard_title_init = GameObject.Find("Canvas/Popup_Card/Card/Title_text");
        popupcard_title = popupcard_title_init.GetComponent<UnityEngine.UI.Text>();
        GameObject popupcard_card_init = GameObject.Find("Canvas/Popup_Card/Card/Card_text");
        popupcard_card = popupcard_card_init.GetComponent<UnityEngine.UI.Text>();  
        popupcard.SetActive(false);       
    }

    /*
    * -------------------------------------------- KETERANGAN -------------------------------------------------
    * NAMA : void disable_object_luar()
    * DESKRIPSI:
    * Fungsi yang digunakan untuk menyembunyikan papan nama kompenen saraf bagian luar
    * STATUS:
    * Done
    * ----------------------------------------------------------------------------------------------------------
    */
    void disable_object_luar()
    {
        GameObject.Find("/ImageTarget/cell_body_detail").SetActive(false);
        GameObject.Find("/ImageTarget/myelin_detail").SetActive(false);
        GameObject.Find("/ImageTarget/dendrite_detail").SetActive(false);
        GameObject.Find("/ImageTarget/sinapsis_detail").SetActive(false);
    }

    /*
    * -------------------------------------------- KETERANGAN -------------------------------------------------
    * NAMA : void disable_object_dalam()
    * DESKRIPSI:
    * Fungsi yang digunakan untuk menyembunyikan papan nama kompenen saraf bagian dalam
    * STATUS:
    * Done
    * ----------------------------------------------------------------------------------------------------------
    */
    void disable_object_dalam()
    {
        GameObject.Find("/ImageTarget/nukleus_detail").SetActive(false);
        GameObject.Find("/ImageTarget/sell_schawann_detail").SetActive(false);
        GameObject.Find("/ImageTarget/akson_detail").SetActive(false);
    }

    /*
    * -------------------------------------------- KETERANGAN -------------------------------------------------
    * NAMA : void initialitation_line_luar()
    * DESKRIPSI:
    * Fungsi yang digunakan untuk membuat garis yang menghubungkan antara nama komponen saraf dengan bagian komponen saraf luar
    * STATUS:
    * Done
    * ----------------------------------------------------------------------------------------------------------
    */
    void initialitation_line_luar()
    {
        // Add a Line Renderer to the GameObject
         cell_body_line = new GameObject().AddComponent<LineRenderer>() as LineRenderer;
         // Set the width of the Line Renderer
         cell_body_line.SetWidth(0.05F, 0.05F);
         // Set the number of vertex fo the Line Renderer
         cell_body_line.SetVertexCount(2);

         // Add a Line Renderer to the GameObject
         myelin_line = new GameObject().AddComponent<LineRenderer>() as LineRenderer;
         // Set the width of the Line Renderer
         myelin_line.SetWidth(0.05F, 0.05F);
         // Set the number of vertex fo the Line Renderer
         myelin_line.SetVertexCount(2);

         // Add a Line Renderer to the GameObject
         dendrite_line = new GameObject().AddComponent<LineRenderer>() as LineRenderer;
         // Set the width of the Line Renderer
         dendrite_line.SetWidth(0.05F, 0.05F);
         // Set the number of vertex fo the Line Renderer
         dendrite_line.SetVertexCount(2);

         // Add a Line Renderer to the GameObject
         sinapsis_line = new GameObject().AddComponent<LineRenderer>() as LineRenderer;
         // Set the width of the Line Renderer
         sinapsis_line.SetWidth(0.05F, 0.05F);
         // Set the number of vertex fo the Line Renderer
         sinapsis_line.SetVertexCount(2);
    }

    /*
    * -------------------------------------------- KETERANGAN -------------------------------------------------
    * NAMA : void initialitation_line_dalam()
    * DESKRIPSI:
    * Fungsi yang digunakan untuk membuat garis yang menghubungkan antara nama komponen saraf dengan bagian komponen saraf dalam
    * STATUS:
    * Done
    * ----------------------------------------------------------------------------------------------------------
    */
    void initialitation_line_dalam()
    {
        // Add a Line Renderer to the GameObject
         sell_schawann_line = new GameObject().AddComponent<LineRenderer>() as LineRenderer;
         // Set the width of the Line Renderer
         sell_schawann_line.SetWidth(0.05F, 0.05F);
         // Set the number of vertex fo the Line Renderer
         sell_schawann_line.SetVertexCount(2);

         // Add a Line Renderer to the GameObject
         akson_line = new GameObject().AddComponent<LineRenderer>() as LineRenderer;
         // Set the width of the Line Renderer
         akson_line.SetWidth(0.05F, 0.05F);
         // Set the number of vertex fo the Line Renderer
         akson_line.SetVertexCount(2);

         // Add a Line Renderer to the GameObject
         nukleus_line = new GameObject().AddComponent<LineRenderer>() as LineRenderer;
         // Set the width of the Line Renderer
         nukleus_line.SetWidth(0.05F, 0.05F);
         // Set the number of vertex fo the Line Renderer
         nukleus_line.SetVertexCount(2);
    }

    /*
    * -------------------------------------------- KETERANGAN -------------------------------------------------
    * NAMA : public void trigger_inisialisasi_line(bool cek)
    * DESKRIPSI:
    * Fungsi yang digunakan untuk menutup popup dari detail materi
    * PARAMETER:
    * bool cek = "NILAI DARI BUTTON"
    * STATUS:
    * Done
    * ----------------------------------------------------------------------------------------------------------
    */
    public void trigger_inisialisasi_line(bool cek)
    {
        if(cek == true)
        {
            if(detail_dalam == true) destroy_line_object_dalam();
            initialitation_line_luar();
            detail_luar = true;
            detail_dalam = false;
        }else
        {
            if(detail_luar == true) destroy_line_object_luar();
            initialitation_line_dalam();
            detail_luar = false;
            detail_dalam = true;
        }
    }

    /*
    * -------------------------------------------- KETERANGAN -------------------------------------------------
    * NAMA : void destroy_line_object_luar()
    * DESKRIPSI:
    * Fungsi yang digunakan untuk menghapus garis yang menghubungkan antara nama komponen saraf dengan bagian komponen saraf luar
    * STATUS:
    * Done
    * ----------------------------------------------------------------------------------------------------------
    */
    void destroy_line_object_luar()
    {
        Destroy(cell_body_line.gameObject, 0);
        Destroy(myelin_line.gameObject, 0);
        Destroy(dendrite_line.gameObject, 0);
        Destroy(sinapsis_line.gameObject, 0);
        /*cell_body_line.enabled = false;
        myelin_line.enabled = false;
        dendrite_line.enabled = false;
        sinapsis_line.enabled = false;*/
    }

    /*
    * -------------------------------------------- KETERANGAN -------------------------------------------------
    * NAMA : void destroy_line_object_dalam()
    * DESKRIPSI:
    * Fungsi yang digunakan untuk menghapus garis yang menghubungkan antara nama komponen saraf dengan bagian komponen saraf dalam
    * STATUS :
    * Done
    * ----------------------------------------------------------------------------------------------------------
    */
    void destroy_line_object_dalam()
    {
        Destroy(sell_schawann_line.gameObject, 0);
        Destroy(akson_line.gameObject, 0);
        Destroy(nukleus_line.gameObject, 0);
        /*sell_schawann_line.enabled = false;
        akson_line.enabled = false;
        nukleus_line.enabled = false;*/
    }

    /*
    * -------------------------------------------- KETERANGAN -------------------------------------------------
    * NAMA : void close_card()
    * DESKRIPSI:
    * Fungsi yang digunakan untuk menutup popup dari detail materi
    * STATUS :
    * Done
    * ----------------------------------------------------------------------------------------------------------
    */
    public void close_card()
    {
        popupcard.SetActive(false);  
    }

    /*
    * -------------------------------------------- KETERANGAN -------------------------------------------------
    * NAMA : void tracking_image(string image_target_name)
    * DESKRIPSI:
    * Fungsi yang digunakan untuk menutup popup dari detail materi
    * PARAMETER:
    * string image_target_name = "NAMA OBJECT"
    * STATUS :
    * Process
    * ----------------------------------------------------------------------------------------------------------
    */
    void tracking_image(string image_target_name)
    {
        GameObject image_target = GameObject.Find(image_target_name);
        DefaultTrackableEventHandler trackable = image_target.GetComponent<DefaultTrackableEventHandler>();
        //var status = trackable.CurrentStatus;
        //return status == TrackableBehaviour.Status.TRACKED;
        Debug.Log("Tracking Image");
        Debug.Log(trackable.cek);
    }
}
