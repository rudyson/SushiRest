import style from "./footerLinks.module.scss"
import footerInsta from "../../../../pics/FooterSocialPics/instaFooter.png";
import footerTelegram from "../../../../pics/FooterSocialPics/telegramFooter.png";
import footerTwitter from "../../../../pics/FooterSocialPics/twitterFooter.png";
import footerFacebook from "../../../../pics/FooterSocialPics/facebookFooter.png";

export const FooterLinks = () => {
    return (
        <div className={style.wrapper}>
            <a href="https://www.instagram.com/" target="_blank">
                <img src={footerInsta}></img>
            </a>
            <a href="https://web.telegram.org/"  target="_blank">
                <img src={footerTelegram}></img>
            </a>
            <a href="https://twitter.com/" target="_blank">
                <img src={footerTwitter}></img>
            </a>
            <a href="https://www.facebook.com/" target="_blank">
                <img src={footerFacebook}></img>
            </a>
        </div>
    );
}
