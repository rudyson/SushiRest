import style from "./map.module.scss";

export const Map = () => {
    return (
            <iframe className={style.myMap} loading="lazy"
                    src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3028.322520946315!2d-74.03028418473549!3d40.622768779341676!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x89c2455fdf29c00d%3A0xfbb3377654c057f0!2s8591%204th%20Ave%2C%20Brooklyn%2C%20NY%2011209%2C%20USA!5e0!3m2!1sen!2sua!4v1679939969641!5m2!1sen!2sua"
                    referrerPolicy="no-referrer-when-downgrade">
            </iframe>
    );
}