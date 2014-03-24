using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace WebServiceIvi
{
    [Serializable]
    public class Contact 
    {

        int _id;
        String _email;
        String _email_st;
        String _password;
        String _simoperator;
        String _cellphone;
        String _cellphone_st;
        String _sn_facebook;
        String _sn_linkedin;
        String _sn_googleplus;
        String _sn_skype;
        String _sn_twitter;
        String _last_refresh;
        String _register_date;
        String _username;
        List<OptEmail> _optemails;
         String _homephone;
         String _homephone_st;
         String _comphone;
         String _comphone_st;
         String _altphone;
         String _altphone_st;
         String _website;
         String _website_st;
         String _sn_facebook_st;
         String _sn_linkedin_st;
         String _sn_googleplus_st;
         String _sn_skype_st;
         String _sn_twitter_st;


         public Contact(int id, String email, String email_st, String password,
                 String simoperator, String cellphone, String cellphone_st,
                 String facebook, String linkedin, String googleplus, String skype,
                 String twitter, String refreshuser, String userregister,
                 String username, List<OptEmail> optemails, String homephone,
                 String homephonest, String comphone, String comphonest,
                 String altphone, String altphonest, String website,
                 String websitest, String facebookst, String linkedinst,
                 String googleplusst, String skypest, String twitterst)
         {
             _id = id;
             _email = email;
             _email_st = email_st;
             _password = password;
             _simoperator = simoperator;
             _cellphone = cellphone;
             _cellphone_st = cellphone_st;
             _sn_facebook = facebook;
             _sn_linkedin = linkedin;
             _sn_googleplus = googleplus;
             _sn_skype = skype;
             _sn_twitter = twitter;
             _last_refresh = refreshuser;
             _register_date = userregister;
             _username = username;
             _optemails = optemails;
             _homephone = homephone;
             _homephone_st = homephonest;
             _comphone = comphone;
             _comphone_st = comphonest;
             _altphone = altphone;
             _altphone_st = altphonest;
             _website = website;
             _website_st = websitest;
             _sn_facebook_st = facebookst;
             _sn_linkedin_st = linkedinst;
             _sn_googleplus_st = googleplusst;
             _sn_skype_st = skypest;
             _sn_twitter_st = twitterst;
         }


        public Contact()
        {
           List<OptEmail> _optemails = new List<OptEmail>();
        }

        
        public int UserId
        {
            set { _id = value; }
            get
            {
                if (_id <= 0) return 0;
                else return _id;
            }
        }
        public string UserEmail
        {
            set { _email = value; }
            get
            {
                if (_email != null) return _email.ToString();
                else return string.Empty;
            }
        }

        public string UserEmailStatus
        {
            set { _email_st = value; }
            get
            {
                if (_email_st != null) return _email_st.ToString();
                else return string.Empty;
            }
        }

        public string UserName
        {
            set { _username = value; }
            get
            {
                if (_username != null) return _username.ToString();
                else return string.Empty;
            }
        }

        public string UserPassword
        {
            set { _password = value; }
            get
            {
                if (_password != null) return _password.ToString();
                else return string.Empty;
            }
        }
        public string UserSimOperator
        {
            set { _simoperator = value; }
            get
            {
                if (_simoperator != null) return _simoperator.ToString();
                else return string.Empty;
            }
        }
        public string UserCellPhone
        {
            set { _cellphone = value; }
            get
            {
                if (_cellphone != null) return _cellphone.ToString();
                else return string.Empty;
            }
        }
        public string UserCellPhoneStatus
        {
            set { _cellphone_st = value; }
            get
            {
                if (_cellphone_st != null) return _cellphone_st.ToString();
                else return string.Empty;
            }
        }
        public string UserFacebook
        {
            set { _sn_facebook = value; }
            get
            {
                if (_sn_facebook != null) return _sn_facebook.ToString();
                else return string.Empty;
            }
        }
        public string UserLinkedin
        {
            set { _sn_linkedin = value; }
            get
            {
                if (_sn_linkedin != null) return _sn_linkedin.ToString();
                else return string.Empty;
            }
        }
        public string UserGoogleplus
        {
            set { _sn_googleplus = value; }
            get
            {
                if (_sn_googleplus != null) return _sn_googleplus.ToString();
                else return string.Empty;
            }
        }
        public string UserSkype
        {
            set { _sn_skype = value; }
            get
            {
                if (_sn_skype != null) return _sn_skype.ToString();
                else return string.Empty;
            }
        }
        public string UserTwitter
        {
            set { _sn_twitter = value; }
            get
            {
                if (_sn_twitter != null) return _sn_twitter.ToString();
                else return string.Empty;
            }
        }
        public String UserLastRefresh
        {
            set { _last_refresh = value; }
            get
            {
                if (_last_refresh != null) return _last_refresh.ToString();
                else return string.Empty;
            }
        }
        public String UserRegisterDate
        {
            set { _register_date = value; }
            get
            {
                if (_register_date != null) return _register_date.ToString();
                else return string.Empty;
            }
        }

        public List<OptEmail> UserOptEmail
        {
            set { _optemails = value; }
            get { return _optemails;  }
        }

        public string UserHomephone
        {
            set { _homephone = value; }
            get
            {
                if (_homephone != null) return _homephone.ToString();
                else return string.Empty;
            }
        }
        public string UserHomephoneStatus
        {
            set { _homephone_st = value; }
            get
            {
                if (_homephone_st != null) return _homephone_st.ToString();
                else return string.Empty;
            }
        }
        public string UserComerphone
        {
            set { _comphone = value; }
            get
            {
                if (_comphone!= null) return _comphone.ToString();
                else return string.Empty;
            }
        }
        public string UserComerphoneStatus
        {
            set { _comphone_st = value; }
            get
            {
                if (_comphone_st != null) return _comphone_st.ToString();
                else return string.Empty;
            }
        }
        public string UserAltphone
        {
            set { _altphone = value; }
            get
            {
                if (_altphone!= null) return _altphone.ToString();
                else return string.Empty;
            }
        }
        public string UserAltphoneStatus
        {
            set { _altphone_st = value; }
            get
            {
                if (_altphone_st != null) return _altphone_st.ToString();
                else return string.Empty;
            }
        }
        public string UserWebsite
        {
            set { _website = value; }
            get
            {
                if (_website!= null) return _website.ToString();
                else return string.Empty;
            }
        }
        public string UserWebsiteStatus
        {
            set { _website_st = value; }
            get
            {
                if (_website_st != null) return _website_st.ToString();
                else return string.Empty;
            }
        }
        public string UserFacebookStatus
        {
            set { _sn_facebook_st = value; }
            get
            {
                if (_sn_facebook_st  != null) return _sn_facebook_st.ToString();
                else return string.Empty;
            }
        }
        public string UserLinkedinStatus
        {
            set { _sn_linkedin_st = value; }
            get
            {
                if (_sn_linkedin_st  != null) return _sn_linkedin_st.ToString();
                else return string.Empty;
            }
        }
        public string UserGoogleplusStatus
        {
            set { _sn_googleplus_st = value; }
            get
            {
                if (_sn_googleplus_st != null) return _sn_googleplus_st.ToString();
                else return string.Empty;
            }
        }
        public string UserSkypeStatus
        {
            set { _sn_skype_st = value; }
            get
            {
                if (_sn_skype_st  != null) return _sn_skype_st.ToString();
                else return string.Empty;
            }
        }
        public string UserTwitterStatus
        {
            set { _sn_twitter_st = value; }
            get
            {
                if (_sn_twitter_st  != null) return _sn_twitter_st.ToString();
                else return string.Empty;
            }
        }

    }

    [Serializable]
    public class OptEmail
    {
        string _email;
        string _email_st;

        public OptEmail(String email, String email_st)
        {
            _email = email;
            _email_st = email_st;
        }
        public OptEmail()
        {

        }
        public string OptUserEmailStatus
        {
            set { _email_st = value; }
            get
            {
                if (_email_st != null) return _email_st.ToString();
                else return string.Empty;
            }
        }

        public string OptUserEmail
        {
            set { _email = value; }
            get
            {
                if (_email != null) return _email.ToString();
                else return string.Empty;
            }
        }
    }
}
