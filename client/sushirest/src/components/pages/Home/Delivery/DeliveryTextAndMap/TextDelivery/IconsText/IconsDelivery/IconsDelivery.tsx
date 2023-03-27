import style from "./IconsDelivery.module.css";
import location from "../../../../../../../../pics/MailPhoneLocation/location.png";
import time from "../../../../../../../../pics/MailPhoneLocation/time.png";
import phone from "../../../../../../../../pics/MailPhoneLocation/phone.png";
import mail from "../../../../../../../../pics/MailPhoneLocation/mail.png";

const IconsDelivery = () => {
    return (
        <div className={style.wrapper}>
            <img className={`${style.icons} ${style.firstIcon}`} src={location}></img>
            <img className={style.icons} src={time}></img>
            <img className={style.icons} src={phone}></img>
            <img className={style.icons} src={mail}></img>
        </div>

    );
}
export default IconsDelivery;