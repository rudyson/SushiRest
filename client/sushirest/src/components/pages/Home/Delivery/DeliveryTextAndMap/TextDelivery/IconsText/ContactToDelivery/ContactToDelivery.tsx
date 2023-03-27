import style from "./ContactToDelivery.module.css";


const ContactToDelivery = () => {
    return (
        <div className={style.wrapper}>
            <p className={`${style.firstText} ${style.text}`}>85-91 4th Ave, New York</p>
            <p className={`${style.secondText} ${style.text}`}>Every day  from 8 am to 10 pm</p>
            <a className={`${style.thirdText} ${style.text}`} href="tel:+5 (555) 553 678">+5 (555) 553 678</a>
            <a className={`${style.fourthText} ${style.text}`} href="mailto:Eugeneshal.web@gmail.com">Eugeneshal.web@gmail.com</a>
        </div>
    );
}
export default ContactToDelivery;