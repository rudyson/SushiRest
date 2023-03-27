import style from "./SocialMedia.module.css"
import insta from "../../../../../../pics/SocialPics/insta.png"
import telegram from "../../../../../../pics/SocialPics/telegram.png"
import twitter from "../../../../../../pics/SocialPics/twitter.png"
import facebook from "../../../../../../pics/SocialPics/facebook.png"

const SocialMedia = () => {
    return (
        <div className={style.wrapper}>
            <a className={`${style.socialLogo} ${style.socialFirst}`} href="https://www.instagram.com/" target="_blank">
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