import style from "./FooterLinks.module.css"
import footerInsta from "../../../../../../pics/FooterSocialPics/instaFooter.png";
import footerTelegram from "../../../../../../pics/FooterSocialPics/telegramFooter.png";
import footerTwitter from "../../../../../../pics/FooterSocialPics/twitterFooter.png";
import footerFacebook from "../../../../../../pics/FooterSocialPics/facebookFooter.png";

const FooterLinks = () => {
    return (
        <div className={style.wrapper}>
            <a className={`${style.socialLink} ${style.socialFirst}`} href="https://www.instagram.com/" target="_blank">
                <img className={style.socialImg} src={footerInsta}></img>
            </a>
            <a className={style.socialLink} href="https://web.telegram.org/"  target="_blank">
                <img className={style.socialImg} src={footerTelegram}></img>
            </a>
            <a className={style.socialLink} href="https://twitter.com/" target="_blank">
                <img className={style.socialImg} src={footerTwitter}></img>
            </a>
            <a className={style.socialLink} href="https://www.facebook.com/" target="_blank">
                <img className={style.socialImg} src={footerFacebook}></img>
            </a>
        </div>
    );
}

export default FooterLinks;