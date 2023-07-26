import style from "./LeftFooter.module.scss"
import {FooterLinks} from "../../../../index.ts";

export const LeftFooter = () => {
    return (
        <div className={style.wrapper}>
            <h1>SushiRest</h1>
            <FooterLinks/>
        </div>
    );
}
