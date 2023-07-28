import style from "./iconsText.module.scss";
import location from "../../../../../../../pics/MailPhoneLocation/location.png";
import time from "../../../../../../../pics/MailPhoneLocation/time.png";
import phone from "../../../../../../../pics/MailPhoneLocation/phone.png";
import mail from "../../../../../../../pics/MailPhoneLocation/mail.png";

const icons = [location, time, phone, mail]

export const IconsText = () => {
    return (
        <div className={style.wrapper}>
            <section className={style.iconsWrapper}>
                {icons.map((el) => (
                    <img src={el}></img>
                ))}
            </section>
            <section className={style.contactWrapper}>
                <p className={style.firstText}>85-91 4th Ave, New York</p>
                <p className={style.secondText}>Every day  from 8 am to 10 pm</p>
                <a className={style.thirdText} href="tel:+5 (555) 553 678">+5 (555) 553 678</a>
                <a className={style.fourthText} href="mailto:Eugeneshal.web@gmail.com">Eugeneshal.web@gmail.com</a>
            </section>
        </div>
    );
}
