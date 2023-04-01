import style from "./LeftFooter.module.css"
import FooterLinks from "./FooterLinks/FooterLinks";

const LeftFooter = () => {
    return (
        <div className={style.wrapper}>
            <h1 className={style.header}>SushiRest</h1>
            <FooterLinks/>
        </div>
    );
}

export default LeftFooter;