using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour {

    private string characterClassName;
    private string characterClassDescription;

    private int endurance;
    private int strengh;
    private int intellect;
    private int life=5;
    private float m_crouchspeed = .36f; //personnage quantite de vitesse applique  1 = 100%
    private float m_maxspeed = 10f; //personnage vitesse max
    private float m_jump = 10f; //personnage force de saut max
    private bool m_aircontrol = false; //personnage peut faire des actions en l'air
    private Transform m_GroundCheck;
    const float k_GroundedRadius = .2f;
    private bool m_Grounded; //personnage au sol
    private Transform m_CeilingCheck;
    const float k_CeilingRadius = .01f;
    private Animator m_Anim;  //animator du personnage
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;
    private LayerMask m_WhatIsGround;

    public string CharacterClassName
    {
        get { return characterClassName; }
        set { characterClassName = value; }
    }

    public string CharacterClassDescription
    {
        get { return characterClassDescription; }
        set { characterClassDescription = value; }
    }

    public int Endurance
    {
        get { return endurance; }
        set { endurance = value; }
    }

    public int Intellect
    {
        get { return intellect; }
        set { intellect = value; }
    }

    public float MaxSpeed
    {
        get { return m_maxspeed; }
        set { m_maxspeed = value; }
    }

    public float MaxJump
    {
        get { return m_jump; }
        set { m_jump = value; }
    }

    public int Strengh
    {
        get { return strengh; }
        set { strengh = value; }
    }

    public bool AirControl
    {
        get { return m_aircontrol; }
        set { m_aircontrol = value; }
    }

    public float CrouchSpeed
    {
        get { return m_crouchspeed; }
        set { m_crouchspeed = value; }
    }

    public int Life
    {
        get { return life; }
        set { life = value; }
    }

    public void Move(float move, bool crouch, bool jump)
    {
        if (!crouch && m_Anim.GetBool("Crouch"))
        {
            if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
            {
                crouch = true;
            }
        }
        m_Anim.SetBool("Crouch", crouch);
        if (m_Grounded || m_aircontrol)
        {
            move = (crouch ? move * m_crouchspeed : move);
            m_Anim.SetFloat("Speed", Mathf.Abs(move));
            m_Rigidbody2D.velocity = new Vector2(move * m_maxspeed, m_Rigidbody2D.velocity.y);
            if (move > 0 && !m_FacingRight)
            {
                Flip();
            }
            else if (move < 0 && m_FacingRight)
            {
                Flip();
            }
        }
        if (m_Grounded && jump && m_Anim.GetBool("Ground"))
        {
            m_Grounded = false;
            m_Anim.SetBool("Ground", false);
            m_Rigidbody2D.AddForce(new Vector2(0f, m_jump));
        }
    }

    //sens du bonhomme
    private void Flip()
    {
        m_FacingRight = !m_FacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
