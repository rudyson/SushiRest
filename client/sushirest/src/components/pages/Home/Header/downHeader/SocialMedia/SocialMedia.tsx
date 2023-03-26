import style from "./SocialMedia.module.css"
import insta from "../../../../../../pics/insta.png"
import telegram from "../../../../../../pics/telegram.png"
import twitter from "../../../../../../pics/twitter.png"
import facebook from "../../../../../../pics/facebook.png"

const SocialMedia = () => {
    return (
        <div className={style.wrapper}>
            <a className={`${style.socialLogo} ${style.SocialFirst}`} href="https://www.instagram.com/" target="_blank">
                <img className={style.socialImg} src={insta}></img>
            </a>
            <a className={style.socialLogo} href="https://web.telegram.org/"  target="_blank">
                <img className={style.socialImg} src={telegram}></img>
            </a>
            <a className={style.socialLogo} href="https://twitter.com/" target="_blank">
                <img className={style.socialImg} src={twitter}></img>
            </a>
            <a className={style.socialLogo} href="https://www.facebook.com/" target="_blank">
                <img className={style.socialImg} src={facebook}></img>
            </a>
        </div>
    );
}
export  default SocialMedia;