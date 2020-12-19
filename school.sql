--
-- PostgreSQL database dump
--

-- Dumped from database version 12.4
-- Dumped by pg_dump version 12.4

-- Started on 2020-12-19 22:01:37

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 217 (class 1259 OID 41393)
-- Name: comment; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.comment (
    id integer NOT NULL,
    course_id integer NOT NULL,
    users_id integer NOT NULL,
    comment_text text NOT NULL,
    creation_date timestamp without time zone NOT NULL
);


ALTER TABLE public.comment OWNER TO postgres;

--
-- TOC entry 216 (class 1259 OID 41391)
-- Name: comment_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.comment_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.comment_id_seq OWNER TO postgres;

--
-- TOC entry 2927 (class 0 OID 0)
-- Dependencies: 216
-- Name: comment_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.comment_id_seq OWNED BY public.comment.id;


--
-- TOC entry 203 (class 1259 OID 41209)
-- Name: course; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.course (
    id integer NOT NULL,
    name character varying(100) NOT NULL,
    description text NOT NULL,
    price integer NOT NULL,
    number_of_students integer DEFAULT 0
);


ALTER TABLE public.course OWNER TO postgres;

--
-- TOC entry 202 (class 1259 OID 41207)
-- Name: course_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.course_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.course_id_seq OWNER TO postgres;

--
-- TOC entry 2928 (class 0 OID 0)
-- Dependencies: 202
-- Name: course_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.course_id_seq OWNED BY public.course.id;


--
-- TOC entry 210 (class 1259 OID 41293)
-- Name: course_to_subject; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.course_to_subject (
    course_id integer NOT NULL,
    subject_id integer NOT NULL
);


ALTER TABLE public.course_to_subject OWNER TO postgres;

--
-- TOC entry 219 (class 1259 OID 41414)
-- Name: file; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.file (
    id integer NOT NULL,
    users_id integer NOT NULL,
    file_name text NOT NULL,
    file_extension character varying(10) NOT NULL
);


ALTER TABLE public.file OWNER TO postgres;

--
-- TOC entry 218 (class 1259 OID 41412)
-- Name: file_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.file_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.file_id_seq OWNER TO postgres;

--
-- TOC entry 2929 (class 0 OID 0)
-- Dependencies: 218
-- Name: file_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.file_id_seq OWNED BY public.file.id;


--
-- TOC entry 207 (class 1259 OID 41271)
-- Name: lesson; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.lesson (
    id integer NOT NULL,
    unit_id integer NOT NULL,
    name character varying(100) NOT NULL,
    content text NOT NULL
);


ALTER TABLE public.lesson OWNER TO postgres;

--
-- TOC entry 206 (class 1259 OID 41269)
-- Name: lesson_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.lesson_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.lesson_id_seq OWNER TO postgres;

--
-- TOC entry 2930 (class 0 OID 0)
-- Dependencies: 206
-- Name: lesson_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.lesson_id_seq OWNED BY public.lesson.id;


--
-- TOC entry 215 (class 1259 OID 41351)
-- Name: purchase; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.purchase (
    id integer NOT NULL,
    users_id integer NOT NULL,
    course_id integer NOT NULL,
    purchase_date timestamp without time zone NOT NULL,
    price integer NOT NULL
);


ALTER TABLE public.purchase OWNER TO postgres;

--
-- TOC entry 214 (class 1259 OID 41349)
-- Name: purchase_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.purchase_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.purchase_id_seq OWNER TO postgres;

--
-- TOC entry 2931 (class 0 OID 0)
-- Dependencies: 214
-- Name: purchase_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.purchase_id_seq OWNED BY public.purchase.id;


--
-- TOC entry 209 (class 1259 OID 41287)
-- Name: subject; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.subject (
    id integer NOT NULL,
    name character varying(50)
);


ALTER TABLE public.subject OWNER TO postgres;

--
-- TOC entry 208 (class 1259 OID 41285)
-- Name: subject_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.subject_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.subject_id_seq OWNER TO postgres;

--
-- TOC entry 2932 (class 0 OID 0)
-- Dependencies: 208
-- Name: subject_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.subject_id_seq OWNED BY public.subject.id;


--
-- TOC entry 205 (class 1259 OID 41258)
-- Name: unit; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.unit (
    id integer NOT NULL,
    course_id integer NOT NULL,
    name character varying(100) NOT NULL,
    number_of_lessons integer NOT NULL
);


ALTER TABLE public.unit OWNER TO postgres;

--
-- TOC entry 204 (class 1259 OID 41256)
-- Name: unit_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.unit_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.unit_id_seq OWNER TO postgres;

--
-- TOC entry 2933 (class 0 OID 0)
-- Dependencies: 204
-- Name: unit_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.unit_id_seq OWNED BY public.unit.id;


--
-- TOC entry 212 (class 1259 OID 41308)
-- Name: users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.users (
    id integer NOT NULL,
    name character varying(50) NOT NULL,
    password character varying(20) NOT NULL,
    registration_date date NOT NULL,
    number_of_courses integer DEFAULT 0
);


ALTER TABLE public.users OWNER TO postgres;

--
-- TOC entry 211 (class 1259 OID 41306)
-- Name: users_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.users_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.users_id_seq OWNER TO postgres;

--
-- TOC entry 2934 (class 0 OID 0)
-- Dependencies: 211
-- Name: users_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.users_id_seq OWNED BY public.users.id;


--
-- TOC entry 213 (class 1259 OID 41315)
-- Name: users_to_course; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.users_to_course (
    users_id integer NOT NULL,
    course_id integer NOT NULL
);


ALTER TABLE public.users_to_course OWNER TO postgres;

--
-- TOC entry 2749 (class 2604 OID 41396)
-- Name: comment id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.comment ALTER COLUMN id SET DEFAULT nextval('public.comment_id_seq'::regclass);


--
-- TOC entry 2741 (class 2604 OID 41212)
-- Name: course id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.course ALTER COLUMN id SET DEFAULT nextval('public.course_id_seq'::regclass);


--
-- TOC entry 2750 (class 2604 OID 41417)
-- Name: file id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.file ALTER COLUMN id SET DEFAULT nextval('public.file_id_seq'::regclass);


--
-- TOC entry 2744 (class 2604 OID 41274)
-- Name: lesson id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.lesson ALTER COLUMN id SET DEFAULT nextval('public.lesson_id_seq'::regclass);


--
-- TOC entry 2748 (class 2604 OID 41354)
-- Name: purchase id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.purchase ALTER COLUMN id SET DEFAULT nextval('public.purchase_id_seq'::regclass);


--
-- TOC entry 2745 (class 2604 OID 41290)
-- Name: subject id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.subject ALTER COLUMN id SET DEFAULT nextval('public.subject_id_seq'::regclass);


--
-- TOC entry 2743 (class 2604 OID 41261)
-- Name: unit id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.unit ALTER COLUMN id SET DEFAULT nextval('public.unit_id_seq'::regclass);


--
-- TOC entry 2746 (class 2604 OID 41311)
-- Name: users id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users ALTER COLUMN id SET DEFAULT nextval('public.users_id_seq'::regclass);


--
-- TOC entry 2919 (class 0 OID 41393)
-- Dependencies: 217
-- Data for Name: comment; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.comment VALUES (1, 1, 1, 'Супер курс! Много полезной информации!', '2020-12-06 13:24:00');
INSERT INTO public.comment VALUES (2, 1, 1, 'Хотя нет, отстой', '2020-12-06 17:11:00');
INSERT INTO public.comment VALUES (3, 2, 1, 'Ожидал большего', '2020-12-08 10:52:00');
INSERT INTO public.comment VALUES (4, 3, 1, 'Сложно, но круто', '2020-12-09 17:35:00');
INSERT INTO public.comment VALUES (5, 1, 1, 'Ха! Здорово!', '2020-12-09 00:00:00');
INSERT INTO public.comment VALUES (6, 1, 1, 'Спасиииибоооо!!!!!!!!', '2020-12-09 21:19:11');
INSERT INTO public.comment VALUES (7, 1, 1, 'Тестовый комментарий', '2020-12-10 23:59:44');
INSERT INTO public.comment VALUES (9, 1, 8, 'Проверка логина', '2020-12-12 01:45:44');
INSERT INTO public.comment VALUES (10, 1, 7, 'Раз два три', '2020-12-12 01:57:06');
INSERT INTO public.comment VALUES (11, 1, 7, 'УРА!!!', '2020-12-12 01:57:17');
INSERT INTO public.comment VALUES (12, 1, 1, 'НАМАЛЬНА', '2020-12-14 17:21:35');
INSERT INTO public.comment VALUES (13, 1, 1, 'Курс полезный!', '2020-12-16 14:40:59');
INSERT INTO public.comment VALUES (14, 3, 11, 'Вау!', '2020-12-19 21:55:49');


--
-- TOC entry 2905 (class 0 OID 41209)
-- Dependencies: 203
-- Data for Name: course; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.course VALUES (2, '2 курс', '2 описание', 50000, 2);
INSERT INTO public.course VALUES (1, '1 курс', '1 описание', 5000, 2);
INSERT INTO public.course VALUES (3, '3 курс', '3 описание', 1000, 4);


--
-- TOC entry 2912 (class 0 OID 41293)
-- Dependencies: 210
-- Data for Name: course_to_subject; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.course_to_subject VALUES (1, 2);
INSERT INTO public.course_to_subject VALUES (1, 1);
INSERT INTO public.course_to_subject VALUES (2, 1);
INSERT INTO public.course_to_subject VALUES (3, 2);
INSERT INTO public.course_to_subject VALUES (3, 4);


--
-- TOC entry 2921 (class 0 OID 41414)
-- Dependencies: 219
-- Data for Name: file; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.file VALUES (1, 1, 'криволинейный интеграл IIтипа', '.pdf');
INSERT INTO public.file VALUES (2, 1, 'Очан сборник задач по матану', '.pdf');
INSERT INTO public.file VALUES (3, 1, 'Берман Сборник задач по курсу матана', '.pdf');
INSERT INTO public.file VALUES (4, 1, 'Винберг Курс алгебры', '.pdf');
INSERT INTO public.file VALUES (5, 1, 'Костыркин Введение в алгебру Ч.2', '.pdf');
INSERT INTO public.file VALUES (6, 1, 'Корнеева Насрутдинов Сборник задач по аналитической геометрии', '.pdf');
INSERT INTO public.file VALUES (7, 1, 'New_English_File_Upper_intermediate_Stud', '.pdf');
INSERT INTO public.file VALUES (8, 1, 'Зубков Корнеева Упражнения и задачи по ДМ Ч.1', '.pdf');
INSERT INTO public.file VALUES (9, 5, 'Гаврилов Сапоженко Задачи и упражнения по ДМ', '.pdf');


--
-- TOC entry 2909 (class 0 OID 41271)
-- Dependencies: 207
-- Data for Name: lesson; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.lesson VALUES (1, 1, 'Давайте знакомиться', 'Это текст первого занятия первого блока');
INSERT INTO public.lesson VALUES (2, 1, 'Что мы узнаем', 'Это текст второго занятия первого блока');
INSERT INTO public.lesson VALUES (3, 2, 'Как строить ракеты', 'Это текст первого занятия второго блока');
INSERT INTO public.lesson VALUES (4, 2, 'Как их запускать в космос', 'Это текст второго занятия второго блока');
INSERT INTO public.lesson VALUES (5, 3, 'Спасибо', 'Это текст первого занятия третьего блока');
INSERT INTO public.lesson VALUES (6, 4, 'Что это такое', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ac felis donec et odio pellentesque diam volutpat. Vestibulum sed arcu non odio euismod lacinia at quis risus. Lacus luctus accumsan tortor posuere. Maecenas accumsan lacus vel facilisis volutpat est velit egestas. Arcu cursus vitae congue mauris rhoncus aenean vel elit. Odio morbi quis commodo odio aenean sed adipiscing diam donec. Eget est lorem ipsum dolor sit amet. Volutpat odio facilisis mauris sit amet massa. Nascetur ridiculus mus mauris vitae ultricies leo integer.');
INSERT INTO public.lesson VALUES (7, 4, 'Как его сделать', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Augue ut lectus arcu bibendum at. Egestas quis ipsum suspendisse ultrices gravida. Adipiscing diam donec adipiscing tristique. Iaculis nunc sed augue lacus. Arcu vitae elementum curabitur vitae nunc sed. Malesuada proin libero nunc consequat interdum varius sit amet. Ultricies mi eget mauris pharetra et ultrices neque ornare aenean. Neque volutpat ac tincidunt vitae semper quis lectus. Duis ut diam quam nulla porttitor massa. Duis tristique sollicitudin nibh sit amet commodo nulla. Sed faucibus turpis in eu mi bibendum neque. Pulvinar neque laoreet suspendisse interdum consectetur libero id faucibus. Enim ut tellus elementum sagittis vitae et leo. Pulvinar pellentesque habitant morbi tristique senectus et netus.');
INSERT INTO public.lesson VALUES (8, 5, 'Выводы', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Cras adipiscing enim eu turpis. Curabitur gravida arcu ac tortor dignissim convallis aenean et tortor. Etiam erat velit scelerisque in. Dolor purus non enim praesent.');
INSERT INTO public.lesson VALUES (9, 5, 'Дополнительно', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Nulla facilisi morbi tempus iaculis. Justo donec enim diam vulputate ut pharetra. Vel risus commodo viverra maecenas. Volutpat ac tincidunt vitae semper. Orci phasellus egestas tellus rutrum tellus pellentesque eu. Ornare suspendisse sed nisi lacus. Non arcu risus quis varius quam quisque id.');
INSERT INTO public.lesson VALUES (10, 6, 'Маленький секрет', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ac odio tempor orci dapibus ultrices in iaculis. Ultrices tincidunt arcu non sodales. Velit laoreet id donec ultrices tincidunt arcu non sodales neque. Ultricies tristique nulla aliquet enim. Eget nunc lobortis mattis aliquam. Habitant morbi tristique senectus et netus et malesuada. Quam nulla porttitor massa id neque aliquam vestibulum. Interdum velit euismod in pellentesque massa placerat duis ultricies lacus. Nulla pellentesque dignissim enim sit amet venenatis urna cursus. Pretium viverra suspendisse potenti nullam ac tortor. Fermentum odio eu feugiat pretium nibh ipsum consequat nisl.');
INSERT INTO public.lesson VALUES (11, 7, 'Делаем расчеты', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Sagittis orci a scelerisque purus semper eget. Nisl rhoncus mattis rhoncus urna. Eu ultrices vitae auctor eu augue. Maecenas volutpat blandit aliquam etiam erat. Ornare massa eget egestas purus viverra accumsan in nisl nisi. Id interdum velit laoreet id donec ultrices tincidunt arcu. Aliquet bibendum enim facilisis gravida neque convallis a. Non quam lacus suspendisse faucibus interdum posuere lorem ipsum. Amet porttitor eget dolor morbi non. Integer vitae justo eget magna. Risus quis varius quam quisque id diam vel. Ultrices sagittis orci a scelerisque purus semper. Vitae proin sagittis nisl rhoncus mattis. Vitae sapien pellentesque habitant morbi tristique senectus et netus. Sed tempus urna et pharetra pharetra massa massa. Ultricies tristique nulla aliquet enim. Diam volutpat commodo sed egestas egestas fringilla phasellus faucibus. Lacus vestibulum sed arcu non. Etiam sit amet nisl purus in.');
INSERT INTO public.lesson VALUES (12, 7, 'Производим тесты', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Vel pharetra vel turpis nunc eget lorem dolor. Purus sit amet volutpat consequat. Scelerisque eleifend donec pretium vulputate sapien. Faucibus purus in massa tempor nec feugiat nisl pretium fusce. Morbi tristique senectus et netus et malesuada fames ac. Scelerisque eu ultrices vitae auctor eu augue ut lectus. At elementum eu facilisis sed odio. Libero volutpat sed cras ornare. Sit amet nisl suscipit adipiscing bibendum est ultricies.');
INSERT INTO public.lesson VALUES (13, 8, 'Радуемся результату', 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Curabitur vitae nunc sed velit dignissim. Sit amet justo donec enim. Pellentesque habitant morbi tristique senectus et netus et malesuada fames. Rutrum tellus pellentesque eu tincidunt tortor aliquam nulla facilisi cras. Ac turpis egestas integer eget.');


--
-- TOC entry 2917 (class 0 OID 41351)
-- Dependencies: 215
-- Data for Name: purchase; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.purchase VALUES (1, 1, 1, '2020-10-12 00:00:00', 5000);
INSERT INTO public.purchase VALUES (2, 1, 2, '2020-12-01 00:00:00', 50000);
INSERT INTO public.purchase VALUES (3, 1, 3, '2020-11-25 00:00:00', 1000);
INSERT INTO public.purchase VALUES (4, 5, 2, '2020-11-19 00:00:00', 50000);
INSERT INTO public.purchase VALUES (5, 5, 3, '2020-12-03 00:00:00', 1000);
INSERT INTO public.purchase VALUES (6, 8, 3, '2020-12-16 02:19:43', 1000);
INSERT INTO public.purchase VALUES (7, 5, 1, '2020-12-16 14:42:29', 5000);
INSERT INTO public.purchase VALUES (8, 11, 3, '2020-12-19 21:55:36', 1000);


--
-- TOC entry 2911 (class 0 OID 41287)
-- Dependencies: 209
-- Data for Name: subject; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.subject VALUES (1, 'математика');
INSERT INTO public.subject VALUES (2, 'физика');
INSERT INTO public.subject VALUES (3, 'экономика');
INSERT INTO public.subject VALUES (4, 'история');


--
-- TOC entry 2907 (class 0 OID 41258)
-- Dependencies: 205
-- Data for Name: unit; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.unit VALUES (1, 1, 'Введение в 1 курс', 2);
INSERT INTO public.unit VALUES (2, 1, 'Продолжение 1-го курса', 2);
INSERT INTO public.unit VALUES (3, 1, 'Заключение 1 курса', 1);
INSERT INTO public.unit VALUES (4, 2, 'Введение', 2);
INSERT INTO public.unit VALUES (5, 2, 'Заключение', 2);
INSERT INTO public.unit VALUES (6, 3, 'С чего начать', 1);
INSERT INTO public.unit VALUES (7, 3, 'Как продолжить', 2);
INSERT INTO public.unit VALUES (8, 3, 'Чем закончить', 1);


--
-- TOC entry 2914 (class 0 OID 41308)
-- Dependencies: 212
-- Data for Name: users; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.users VALUES (7, 'Ooo', 'Parol1', '2020-12-11', 0);
INSERT INTO public.users VALUES (1, 'Kirill', '123', '2020-11-20', 3);
INSERT INTO public.users VALUES (8, 'Timur', 'Timur1', '2020-12-12', 1);
INSERT INTO public.users VALUES (5, 'Test', 'Parol1', '2020-12-11', 3);
INSERT INTO public.users VALUES (9, 'Name', 'Parol1', '2020-12-19', 0);
INSERT INTO public.users VALUES (10, 'Login', 'Parol1', '2020-12-19', 0);
INSERT INTO public.users VALUES (11, 'Sasha', 'Parol1', '2020-12-19', 1);


--
-- TOC entry 2915 (class 0 OID 41315)
-- Dependencies: 213
-- Data for Name: users_to_course; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.users_to_course VALUES (1, 1);
INSERT INTO public.users_to_course VALUES (1, 2);
INSERT INTO public.users_to_course VALUES (1, 3);
INSERT INTO public.users_to_course VALUES (5, 2);
INSERT INTO public.users_to_course VALUES (5, 3);
INSERT INTO public.users_to_course VALUES (8, 3);
INSERT INTO public.users_to_course VALUES (5, 1);
INSERT INTO public.users_to_course VALUES (11, 3);


--
-- TOC entry 2935 (class 0 OID 0)
-- Dependencies: 216
-- Name: comment_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.comment_id_seq', 14, true);


--
-- TOC entry 2936 (class 0 OID 0)
-- Dependencies: 202
-- Name: course_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.course_id_seq', 3, true);


--
-- TOC entry 2937 (class 0 OID 0)
-- Dependencies: 218
-- Name: file_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.file_id_seq', 9, true);


--
-- TOC entry 2938 (class 0 OID 0)
-- Dependencies: 206
-- Name: lesson_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.lesson_id_seq', 13, true);


--
-- TOC entry 2939 (class 0 OID 0)
-- Dependencies: 214
-- Name: purchase_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.purchase_id_seq', 8, true);


--
-- TOC entry 2940 (class 0 OID 0)
-- Dependencies: 208
-- Name: subject_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.subject_id_seq', 4, true);


--
-- TOC entry 2941 (class 0 OID 0)
-- Dependencies: 204
-- Name: unit_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.unit_id_seq', 8, true);


--
-- TOC entry 2942 (class 0 OID 0)
-- Dependencies: 211
-- Name: users_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.users_id_seq', 11, true);


--
-- TOC entry 2764 (class 2606 OID 41401)
-- Name: comment comment_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.comment
    ADD CONSTRAINT comment_pkey PRIMARY KEY (id);


--
-- TOC entry 2752 (class 2606 OID 41218)
-- Name: course course_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.course
    ADD CONSTRAINT course_pkey PRIMARY KEY (id);


--
-- TOC entry 2766 (class 2606 OID 41419)
-- Name: file file_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.file
    ADD CONSTRAINT file_pkey PRIMARY KEY (id);


--
-- TOC entry 2756 (class 2606 OID 41279)
-- Name: lesson lesson_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.lesson
    ADD CONSTRAINT lesson_pkey PRIMARY KEY (id);


--
-- TOC entry 2762 (class 2606 OID 41356)
-- Name: purchase purchase_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.purchase
    ADD CONSTRAINT purchase_pkey PRIMARY KEY (id);


--
-- TOC entry 2758 (class 2606 OID 41292)
-- Name: subject subject_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.subject
    ADD CONSTRAINT subject_pkey PRIMARY KEY (id);


--
-- TOC entry 2754 (class 2606 OID 41263)
-- Name: unit unit_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.unit
    ADD CONSTRAINT unit_pkey PRIMARY KEY (id);


--
-- TOC entry 2760 (class 2606 OID 41314)
-- Name: users users_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (id);


--
-- TOC entry 2775 (class 2606 OID 41402)
-- Name: comment comment_course_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.comment
    ADD CONSTRAINT comment_course_id_fkey FOREIGN KEY (course_id) REFERENCES public.course(id) ON DELETE CASCADE;


--
-- TOC entry 2776 (class 2606 OID 41407)
-- Name: comment comment_users_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.comment
    ADD CONSTRAINT comment_users_id_fkey FOREIGN KEY (users_id) REFERENCES public.users(id) ON DELETE CASCADE;


--
-- TOC entry 2769 (class 2606 OID 41296)
-- Name: course_to_subject course_to_subject_course_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.course_to_subject
    ADD CONSTRAINT course_to_subject_course_id_fkey FOREIGN KEY (course_id) REFERENCES public.course(id) ON DELETE CASCADE;


--
-- TOC entry 2770 (class 2606 OID 41301)
-- Name: course_to_subject course_to_subject_subject_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.course_to_subject
    ADD CONSTRAINT course_to_subject_subject_id_fkey FOREIGN KEY (subject_id) REFERENCES public.subject(id) ON DELETE CASCADE;


--
-- TOC entry 2777 (class 2606 OID 41420)
-- Name: file file_users_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.file
    ADD CONSTRAINT file_users_id_fkey FOREIGN KEY (users_id) REFERENCES public.users(id) ON DELETE CASCADE;


--
-- TOC entry 2768 (class 2606 OID 41280)
-- Name: lesson lesson_unit_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.lesson
    ADD CONSTRAINT lesson_unit_id_fkey FOREIGN KEY (unit_id) REFERENCES public.unit(id) ON DELETE CASCADE;


--
-- TOC entry 2774 (class 2606 OID 41362)
-- Name: purchase purchase_course_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.purchase
    ADD CONSTRAINT purchase_course_id_fkey FOREIGN KEY (course_id) REFERENCES public.course(id) ON DELETE CASCADE;


--
-- TOC entry 2773 (class 2606 OID 41357)
-- Name: purchase purchase_users_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.purchase
    ADD CONSTRAINT purchase_users_id_fkey FOREIGN KEY (users_id) REFERENCES public.users(id) ON DELETE CASCADE;


--
-- TOC entry 2767 (class 2606 OID 41264)
-- Name: unit unit_course_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.unit
    ADD CONSTRAINT unit_course_id_fkey FOREIGN KEY (course_id) REFERENCES public.course(id) ON DELETE CASCADE;


--
-- TOC entry 2772 (class 2606 OID 41323)
-- Name: users_to_course users_to_course_course_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users_to_course
    ADD CONSTRAINT users_to_course_course_id_fkey FOREIGN KEY (course_id) REFERENCES public.course(id) ON DELETE CASCADE;


--
-- TOC entry 2771 (class 2606 OID 41318)
-- Name: users_to_course users_to_course_users_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users_to_course
    ADD CONSTRAINT users_to_course_users_id_fkey FOREIGN KEY (users_id) REFERENCES public.users(id) ON DELETE CASCADE;


-- Completed on 2020-12-19 22:01:39

--
-- PostgreSQL database dump complete
--

