import style from "./socialMedia.module.scss"
import insta from "../../../../pics/HeaderSocialPics/insta.png"
import telegram from "../../../../pics/HeaderSocialPics/telegram.png"
import twitter from "../../../../pics/HeaderSocialPics/twitter.png"
import facebook from "../../../../pics/HeaderSocialPics/facebook.png"

export const SocialMedia = () => {
    return (
        <div className={style.wrapper}>
            <a className={style.socialLink} href="https://www.instagram.com/" target="_blank">
                <img src={insta}></img>
            </a>
            <a className={style.socialLink} href="https://web.telegram.org/"  target="_blank">
                <img src={telegram}></img>
            </a>
            <a className={style.socialLink} href="https://twitter.com/" target="_blank">
                <img src={twitter}></img>
            </a>
            <a className={style.socialLink} href="https://www.facebook.com/" target="_blank">
                <img src={facebook}></img>
            </a>
        </div>
    );
}
